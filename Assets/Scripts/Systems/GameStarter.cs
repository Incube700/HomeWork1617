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
            SpawnEntry entry = _spawns[i];

            Vector3 position = entry.point != null ? entry.point.position : Vector3.zero;
            GameObject enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);

            if (enemy.GetComponent<CharacterMover>() == null)      enemy.AddComponent<CharacterMover>();
            if (enemy.GetComponent<DistanceAggroSensor>() == null) enemy.AddComponent<DistanceAggroSensor>();

            EnemyController controller = enemy.GetComponent<EnemyController>();
            if (controller == null) controller = enemy.AddComponent<EnemyController>();

            WaypointPath path = entry.routeOverride != null ? entry.routeOverride : _sharedPath;

            controller.Initialize(_player, entry.idle, entry.alert, path);
        }
    }
}