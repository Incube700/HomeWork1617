using UnityEngine;

public class AlertPanicDie : IEnemyBehavior
{
    private readonly Transform _self;

    public AlertPanicDie(Transform self)
    {
        _self = self;
    }

    public void Tick(float dt)
    {
        Object.Destroy(_self.gameObject);
    }
}