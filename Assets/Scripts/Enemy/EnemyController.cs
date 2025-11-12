using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(DistanceAggroSensor))]
public class EnemyController : MonoBehaviour
{
    private const float EnemySpeed = 4.0f;

    private Transform _player;
    private CharacterMover _mover;
    private DistanceAggroSensor _sensor;

    private IIdleBehavior _idle;
    private IAlertBehavior _alert;

    public void Initialize(Transform player,
        IdleBehaviorType idleType,
        AlertBehaviorType alertType,
        WaypointPath sharedPath)
    {
        _player = player;
        _mover  = GetComponent<CharacterMover>();
        _sensor = GetComponent<DistanceAggroSensor>();

        _idle  = BehaviorFactory.CreateIdle(idleType,  sharedPath, EnemySpeed);
        _alert = BehaviorFactory.CreateAlert(alertType, EnemySpeed);
    }

    private void FixedUpdate()
    {
        if (_player == null || _mover == null || _sensor == null)
        {
            return;
        }

        bool isAggro = _sensor.IsAggro(transform, _player);
        float deltaTime = Time.fixedDeltaTime;

        if (isAggro == false)
        {
            _idle.Tick(transform, _mover, deltaTime);
        }
        else
        {
            _alert.Tick(transform, _player, _mover, deltaTime);
        }
    }
}