using UnityEngine;

public class DistanceAggroSensor : MonoBehaviour
{
    private const float AggroRadiusMeters = 6.0f;

    public bool IsAggro(Transform self, Transform player)
    {
        Vector3 a = new Vector3(self.position.x, 0f, self.position.z);
        Vector3 b = new Vector3(player.position.x, 0f, player.position.z);

        float sqr = (a - b).sqrMagnitude;
        float limit = AggroRadiusMeters * AggroRadiusMeters;
        return sqr <= limit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AggroRadiusMeters);
    }
}