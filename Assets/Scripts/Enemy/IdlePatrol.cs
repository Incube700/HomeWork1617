using UnityEngine;

public class IdlePatrol : IIdleBehavior
{
    private readonly WaypointPath _path;
    private readonly float _speed;
    private int _index;
    private const float ReachDistance = 0.30f;

    public IdlePatrol(WaypointPath path, float speedMetersPerSecond)
    {
        _path = path;
        _speed = speedMetersPerSecond;
        _index = 0;
    }

    public void Tick(Transform self, CharacterMover mover, float dt)
    {
        if (_path == null || _path.Count < 2)
            return;

        Vector3 target = _path.GetPoint(_index);

        // --- игнорируем Y при проверке расстояния ---
        Vector3 selfXZ = new Vector3(self.position.x, 0f, self.position.z);
        Vector3 targetXZ = new Vector3(target.x, 0f, target.z);
        float distance = Vector3.Distance(selfXZ, targetXZ);
        // -------------------------------------------

        if (distance <= ReachDistance)
        {
            _index = (_index + 1) % _path.Count;
            target = _path.GetPoint(_index);
        }

        mover.MoveTowards(target, _speed, dt);
    }
}