using UnityEngine;

public class IdlePatrol : IIdleBehavior
{
    private readonly WaypointPath _path;
    private readonly float _speed;
    private int _index;

    private const float ReachDistance = 0.30f; // 30 см

    public IdlePatrol(WaypointPath path, float speedMetersPerSecond)
    {
        _path = path;
        _speed = speedMetersPerSecond;
        _index = 0;
    }

    public void Tick(Transform self, CharacterMover mover, float dt)
    {
        if (_path == null || _path.Count < 2)
        {
            return;
        }

        Vector3 target = _path.GetPoint(_index);
        float distance = Vector3.Distance(self.position, target);

        if (distance <= ReachDistance)
        {
            _index++;
            if (_index >= _path.Count)
            {
                _index = 0;
            }
            target = _path.GetPoint(_index);
        }

        mover.MoveTowards(target, _speed, dt);
    }
}