using UnityEngine;

public class IdleWander : IEnemyBehavior
{
    private readonly Transform _self;
    private readonly CharacterMover _mover;
    private readonly float _speed;

    private Vector3 _currentTarget;
    private float _changeTimer;
    private const float ChangeInterval = 1.0f;

    public IdleWander(Transform self, CharacterMover mover, float speedMetersPerSecond)
    {
        _self  = self;
        _mover = mover;
        _speed = speedMetersPerSecond;
        PickNewDirection();
    }

    public void Tick(float dt)
    {
        _changeTimer -= dt;
        if (_changeTimer <= 0f)
        {
            PickNewDirection();
        }

        _mover.MoveTowards(_currentTarget, _speed, dt);
    }

    private void PickNewDirection()
    {
        _changeTimer = ChangeInterval;

        Vector2 circle = Random.insideUnitCircle.normalized;
        Vector3 dir = new Vector3(circle.x, 0f, circle.y);

        _currentTarget = _self.position + dir;
    }
}