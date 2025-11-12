public static class BehaviorFactory
{
    public static IIdleBehavior CreateIdle(IdleBehaviorType type, WaypointPath path, float enemySpeed)
    {
        switch (type)
        {
            case IdleBehaviorType.Stay:   return new IdleStay();
            case IdleBehaviorType.Patrol: return new IdlePatrol(path, enemySpeed);
            case IdleBehaviorType.Wander: return new IdleWander(enemySpeed);
        }
        return new IdleStay();
    }

    public static IAlertBehavior CreateAlert(AlertBehaviorType type, float enemySpeed)
    {
        switch (type)
        {
            case AlertBehaviorType.Chase:    return new AlertChase(enemySpeed);
            case AlertBehaviorType.Flee:     return new AlertFlee(enemySpeed);
            case AlertBehaviorType.PanicDie: return new AlertPanicDie();
        }
        return new AlertChase(enemySpeed);
    }
}
