using UnityEngine;

public class IdlePatrol : IEnemyBehavior
{
    private readonly Transform _self;
    private readonly CharacterMover _mover;
    private readonly WaypointPath _path;
    private readonly float _speed;

    private int _index;
    private const float ReachDistance = 0.30f;

    public IdlePatrol(Transform self, CharacterMover mover, WaypointPath path, float speedMetersPerSecond)
    {
        _self  = self;
        _mover = mover;
        _path  = path;
        _speed = speedMetersPerSecond;
        _index = 0;
    }

    public void Tick(float dt)
    {
        if (_path == null || _path.Count < 2)
        {
            return;
        }

        Vector3 target = _path.GetPoint(_index);

        // сравниваем только по XZ, чтобы не залипать по высоте
        Vector3 selfXZ   = new Vector3(_self.position.x, 0f, _self.position.z);
        Vector3 targetXZ = new Vector3(target.x,        0f, target.z);
        float distance   = Vector3.Distance(selfXZ, targetXZ);

        if (distance <= ReachDistance)
        {
            _index = (_index + 1) % _path.Count;
            target = _path.GetPoint(_index);
        }

        _mover.MoveTowards(target, _speed, dt);
    }
}
