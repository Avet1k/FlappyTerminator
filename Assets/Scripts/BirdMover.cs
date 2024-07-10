using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _flapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private KeyCode _jumpKey = KeyCode.Space;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            _rigidbody2D.velocity = new Vector2(_speed, _flapForce);
            transform.rotation = _maxRotation;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
