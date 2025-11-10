using UnityEngine;

[DisallowMultipleComponent]
public class CharacterMover : MonoBehaviour
{
    private const float MoveSpeed = 3.0f;   
    private const float TurnSpeed = 10.0f;  
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void MoveTowards(Vector3 targetWorldPosition, float deltaTime)
    {
        Vector3 toTarget = targetWorldPosition - transform.position;  
        toTarget.y = 0f;                                              

        if (toTarget.sqrMagnitude <= 0.0001f)                         
        {
            return;
        }

        Vector3 direction = toTarget.normalized;                      
        Vector3 delta = direction * MoveSpeed * deltaTime;            

        if (_rigidbody != null)                                      
        {
            _rigidbody.MovePosition(_rigidbody.position + delta);
        }
        else
        {
            transform.position += delta;                             
        }

        Quaternion look = Quaternion.LookRotation(direction);         
        transform.rotation = Quaternion.Slerp(transform.rotation, look, TurnSpeed * deltaTime);
    }
}