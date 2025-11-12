using UnityEngine;

public class AlertChase : IAlertBehavior
{
    private readonly float _speed;

    public AlertChase(float speedMetersPerSecond)
    {
        _speed = speedMetersPerSecond;
    }

    public void Tick(Transform self, Transform player, CharacterMover mover, float dt)
    {
        mover.MoveTowards(player.position, _speed, dt);
    }
}