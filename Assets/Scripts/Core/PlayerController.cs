using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class PlayerController : MonoBehaviour
{
    private const float PlayerSpeed = 7.0f;
    private CharacterMover _mover;
    private Vector3 _inputDir;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _inputDir = new Vector3(h, 0f, v).normalized;
    }

    private void FixedUpdate()
    {
        if (_inputDir.sqrMagnitude > 0f)
        {
            _mover.MoveTowards(transform.position + _inputDir, PlayerSpeed, Time.fixedDeltaTime);
        }
    }
}