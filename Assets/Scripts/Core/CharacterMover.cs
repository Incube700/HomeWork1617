using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private const float TurnSpeed = 7.0f;
    private const float DefaultSpeed = 4.0f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void MoveTowards(Vector3 targetWorldPosition, float speedMetersPerSecond, float deltaTime)
    {
        Vector3 toTarget = targetWorldPosition - transform.position;
        toTarget.y = 0f; 

        if (toTarget.sqrMagnitude <= 0.0001f)
        {
            return;
        }
        
        float speed = speedMetersPerSecond > 0f ? speedMetersPerSecond : DefaultSpeed;

        Vector3 direction = toTarget.normalized;
        Vector3 step = direction * speed * deltaTime;

        if (_rigidbody != null)
        {
            _rigidbody.MovePosition(_rigidbody.position + step);
        }
        else
        {
            transform.position += step;
        }
        
        Vector3 flatDir = new Vector3(direction.x, 0f, direction.z);
        if (flatDir.sqrMagnitude > 0.0001f)
        {
            Quaternion look = Quaternion.LookRotation(flatDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, TurnSpeed * deltaTime);
        }
    }
}