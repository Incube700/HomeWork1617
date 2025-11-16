using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEntry
{
    public Transform point;
    public IdleBehaviorType idle;
    public AlertBehaviorType alert;
    public WaypointPath routeOverride;
}

public class GameStarter : MonoBehaviour
{
    [Header("Scene references")] [SerializeField]
    private Transform _player;

    [SerializeField] private EnemyController _enemyPrefab; // ВАЖНО: тип EnemyController
    [SerializeField] private WaypointPath _sharedPath;

    [Header("Spawns")] [SerializeField] private List<SpawnEntry> _spawns = new List<SpawnEntry>();

    private const float EnemySpeed = 3.0f;

    private void Start()
    {
        for (int i = 0; i < _spawns.Count; i++)
        {
            SpawnEntry entry = _spawns[i];

            Vector3 position = entry.point != null ? entry.point.position : Vector3.zero;
            EnemyController enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);

            CharacterMover mover = enemy.GetComponent<CharacterMover>();
            DistanceAggroSensor sensor = enemy.GetComponent<DistanceAggroSensor>();

            sensor.Initialize(enemy.transform, _player);

            WaypointPath path =
                entry.routeOverride != null
                    ? entry.routeOverride
                    : _sharedPath;

            IEnemyBehavior idleBehavior = CreateIdleBehavior(entry.idle, enemy.transform, mover, path);
            IEnemyBehavior alertBehavior = CreateAlertBehavior(entry.alert, enemy.transform, mover, _player);

            enemy.Initialize(sensor, idleBehavior, alertBehavior);
        }
    }

    private IEnemyBehavior CreateIdleBehavior(
        IdleBehaviorType type,
        Transform self,
        CharacterMover mover,
        WaypointPath path)
    {
        switch (type)
        {
            case IdleBehaviorType.Stay:
                return new IdleStay();

            case IdleBehaviorType.Patrol:
                return new IdlePatrol(self, mover, path, EnemySpeed);

            case IdleBehaviorType.Wander:
                return new IdleWander(self, mover, EnemySpeed);

            default:
                return new IdleStay();
        }
    }

    private IEnemyBehavior CreateAlertBehavior(
        AlertBehaviorType type,
        Transform self,
        CharacterMover mover,
        Transform player)
    {
        switch (type)
        {
            case AlertBehaviorType.Chase:
                return new AlertChase(player, mover, EnemySpeed);

            case AlertBehaviorType.Flee:
                return new AlertFlee(self, player, mover, EnemySpeed);

            case AlertBehaviorType.PanicDie:
                return new AlertPanicDie(self);

            default:
                return new AlertChase(player, mover, EnemySpeed);
        }
    }
}