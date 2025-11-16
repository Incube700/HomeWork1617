using UnityEngine;

public class DistanceAggroSensor : MonoBehaviour
{
    private const float AggroRadiusMeters = 6.0f;

    private Transform _self;
    private Transform _player;

    public void Initialize(Transform self, Transform player)
    {
        _self = self;
        _player = player;
    }

    public bool IsAggro()
    {
        if (_self == null || _player == null)
        {
            return false;
        }

        Vector3 a = new Vector3(_self.position.x, 0f, _self.position.z);
        Vector3 b = new Vector3(_player.position.x, 0f, _player.position.z);

        float sqr = (a - b).sqrMagnitude;
        float limit = AggroRadiusMeters * AggroRadiusMeters;
        return sqr <= limit;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AggroRadiusMeters);
    }
}