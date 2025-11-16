using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(DistanceAggroSensor))]
public class EnemyController : MonoBehaviour
{
    private DistanceAggroSensor _sensor;

    private IEnemyBehavior _idleBehavior;
    private IEnemyBehavior _alertBehavior;
    private IEnemyBehavior _currentBehavior;

    public void Initialize(DistanceAggroSensor sensor,
        IEnemyBehavior idleBehavior,
        IEnemyBehavior alertBehavior)
    {
        _sensor        = sensor;
        _idleBehavior  = idleBehavior;
        _alertBehavior = alertBehavior;
        _currentBehavior = _idleBehavior;
    }

    private void FixedUpdate()
    {
        if (_sensor == null || _idleBehavior == null || _alertBehavior == null)
        {
            return;
        }

        bool isAggro = _sensor.IsAggro();
        _currentBehavior = isAggro ? _alertBehavior : _idleBehavior;

        _currentBehavior.Tick(Time.fixedDeltaTime);
    }
}