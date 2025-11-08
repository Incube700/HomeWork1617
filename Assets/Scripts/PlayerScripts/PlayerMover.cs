using System;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class PlayerMover : MonoBehaviour
    {
        private const float MoveSpeed = 6.0f;
        private const float TurnSpeed = 12.0f;
        
        private Rigidbody _rigidbody;
        private Vector3 _moveInput;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ReadInput();

            if (_moveInput.sqrMagnitude > 0.0001f)
            {
                Quaternion target = Quaternion.LookRotation(_moveInput);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * TurnSpeed);
            }
        }

        private void FixedUpdate()
        {
            Vector3 next = _rigidbody.position + _moveInput * MoveSpeed * Time.fixedDeltaTime;
               
            _rigidbody.MovePosition(next);
        }
        private void ReadInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            
            _moveInput = direction.normalized;
        }
    }
}
