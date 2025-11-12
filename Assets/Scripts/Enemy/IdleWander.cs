using UnityEngine;

public class IdleWander : IIdleBehavior
{
    private readonly float _speed;
    private Vector3 _dir;
    private float _timer;

    private const float ChangeInterval = 1.0f;

    public IdleWander(float speedMetersPerSecond)
    {
        _speed = speedMetersPerSecond;
    }

    public void Tick(Transform self, CharacterMover mover, float dt)
    {
        _timer -= dt;
        if (_timer <= 0f)
        {
            Vector2 r = Random.insideUnitCircle.normalized;
            _dir = new Vector3(r.x, 0f, r.y);
            _timer = ChangeInterval;
        }

        mover.MoveTowards(self.position + _dir, _speed, dt);
    }
}