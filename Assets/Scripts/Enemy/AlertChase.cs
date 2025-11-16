using UnityEngine;

public class AlertChase : IEnemyBehavior
{
    private readonly Transform _player;
    private readonly CharacterMover _mover;
    private readonly float _speed;

    public AlertChase(Transform player, CharacterMover mover, float speedMetersPerSecond)
    {
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

        _mover.MoveTowards(_player.position, _speed, dt);
    }
}