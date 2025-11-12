using UnityEngine;

public class AlertPanicDie : IAlertBehavior
{
    public void Tick(Transform self, Transform player, CharacterMover mover, float dt)
    {
        Object.Destroy(self.gameObject);
       //тут нужно заспавнить партикл
    }
}