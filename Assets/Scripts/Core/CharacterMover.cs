using UnityEngine;

[DisallowMultipleComponent]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _turnLerpSpeed = 10.0f; // плавность поворота
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Перегрузка со скоростью: все вызывают именно её
    public void MoveTowards(Vector3 targetWorldPosition, float speedMetersPerSecond, float deltaTime)
    {
        Vector3 toTarget = targetWorldPosition - transform.position;
        toTarget.y = 0f;

        if (toTarget.sqrMagnitude <= 0.0001f)
        {
            return;
        }

        Vector3 direction = toTarget.normalized;
        Vector3 delta = direction * speedMetersPerSecond * deltaTime;

        if (_rigidbody != null)
        {
            _rigidbody.MovePosition(_rigidbody.position + delta);
        }
        else
        {
            transform.position += delta;
        }

        Quaternion look = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, _turnLerpSpeed * deltaTime);
    }
}