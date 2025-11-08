using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private const float MoveSpeed = 3.0f;
    private const float TurnSpeed = 10.0f;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveTowards(Vector3 targetWorldPosition - transform.position);
    toTarget.y = 0f;
        
        if (toTarget.sqrMagnitude <= 0.0001f)
    {
        return 
    }

}
