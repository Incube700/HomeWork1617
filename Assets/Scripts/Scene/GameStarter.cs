using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEntry
{
    public Transform point;                 // где спавнить
    public IdleBehaviorType idle;           // поведение покоя
    public AlertBehaviorType alert;         // поведение реакции
    public WaypointPath routeOverride;      // опционально: свой маршрут (если null — общий)
}

public class GameStarter : MonoBehaviour
{
    [Header("Scene references")]
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private WaypointPath _sharedPath;

    [Header("Spawns")]
    [SerializeField] private List<SpawnEntry> _spawns = new List<SpawnEntry>();

    private void Start()
    {
        for (int i = 0; i < _spawns.Count; i++)
        {
            SpawnEntry e = _spawns[i];

            Vector3 pos = e.point != null ? e.point.position : Vector3.zero;
            GameObject enemy = Instantiate(_enemyPrefab, pos, Quaternion.identity);

            if (enemy.GetComponent<CharacterMover>() == null)      enemy.AddComponent<CharacterMover>();
            if (enemy.GetComponent<DistanceAggroSensor>() == null) enemy.AddComponent<DistanceAggroSensor>();

            EnemyController ctrl = enemy.GetComponent<EnemyController>();
            if (ctrl == null) ctrl = enemy.AddComponent<EnemyController>();

            WaypointPath path = e.routeOverride != null ? e.routeOverride : _sharedPath;

            ctrl.Initialize(_player, e.idle, e.alert, path);
        }
    }
}