using Homework2.Config;
using UnityEngine;
using Zenject;

namespace Homework2.Mechanics.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Vector3 _groundCheckHalfExtents = new(0.2f, 0.2f, 0.2f);
        [SerializeField] private Vector3 _groundCheckOffset = new(0.0f, -0.5f, 0.0f);
        
        [Inject] private GameSettings _settings;

        private bool _isGrounded;

        private void FixedUpdate()
        {
            CheckGround();
            
            if (_isGrounded)
            {
                Jump();
            }
            
            ApplyHorizontalMovement();
        }

        private void CheckGround()
        {
            var checkPosition = transform.position + _groundCheckOffset;
            _isGrounded = Physics.CheckBox(checkPosition, _groundCheckHalfExtents, Quaternion.identity, _groundLayer);
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0.0f, _rigidbody.velocity.z);
            _rigidbody.AddForce(Vector3.up * _settings.JumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

        private void ApplyHorizontalMovement()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            _rigidbody.velocity = new Vector3(horizontalInput * _settings.MoveSpeed, _rigidbody.velocity.y, 0.0f);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + _groundCheckOffset, _groundCheckHalfExtents * 2.0f);
        }
#endif
    }
}