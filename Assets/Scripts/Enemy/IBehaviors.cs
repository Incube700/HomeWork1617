using UnityEngine;

public interface IIdleBehavior
{
    void Tick(Transform self, CharacterMover mover, float deltaTime);
}

public interface IAlertBehavior
{
    void Tick(Transform self, Transform player, CharacterMover mover, float deltaTime);
}