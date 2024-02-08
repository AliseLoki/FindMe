using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _rotateSpeed = 10f;

    private bool _isWalking;

    public bool IsWalking => _isWalking;

    private void Update()
    {
        Rotate(Move());
    }

    private void Rotate(Vector3 movement)
    {
        transform.forward = Vector3.Slerp(transform.forward, movement, Time.deltaTime * _rotateSpeed);
    }

    private Vector3 Move()
    {
        float verticalInput = Input.GetAxis(Vertical);
        float horizontalInput = Input.GetAxis(Horizontal);

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        transform.position += _moveSpeed * Time.deltaTime * movement;

        _isWalking = movement != Vector3.zero;

        return movement;
    }
}
