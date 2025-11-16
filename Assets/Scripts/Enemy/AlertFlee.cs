using UnityEngine;

public class AlertFlee : IEnemyBehavior
{
    private readonly Transform _self;
    private readonly Transform _player;
    private readonly CharacterMover _mover;
    private readonly float _speed;

    public AlertFlee(Transform self, Transform player, CharacterMover mover, float speedMetersPerSecond)
    {
        _self   = self;
        _player = player;
        _mover  = mover;
        _speed  = speedMetersPerSecond;
    }

    public void Tick(float dt)
    {
        if (_player == null)
        {
            return;
        }

        Vector3 fromPlayer = _self.position - _player.position;
        Vector3 target = _self.position + fromPlayer.normalized; // отходим от игрока

        _mover.MoveTowards(target, _speed, dt);
    }
}