using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class PlayerController : MonoBehaviour
{
    private const float PlayerSpeed = 4.0f; // скорость игрока

    private CharacterMover _mover;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0f, v).normalized;
        if (dir.sqrMagnitude > 0f)
        {
            _mover.MoveTowards(transform.position + dir, PlayerSpeed, Time.deltaTime);
        }
    }
}