using UnityEngine;

public class AlertFlee : IAlertBehavior
{
    private readonly float _speed;

    public AlertFlee(float speedMetersPerSecond)
    {
        _speed = speedMetersPerSecond;
    }

    public void Tick(Transform self, Transform player, CharacterMover mover, float dt)
    {
        Vector3 fromPlayer = self.position - player.position;
        Vector3 fleeTarget = self.position + fromPlayer;
        mover.MoveTowards(fleeTarget, _speed, dt);
    }
}