using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float LeftRightSpeed = 1.5f;
    public float ForwardMaxSpeed = 0.7f;
    [Range(0, 3)] public float AccelerationSpeed = 3f;

    private bool InTar = false;
    private float CurrentMaxSpeed;
    private float CurrentSpeed;
    private float CurrentVelocity;

    private Rigidbody _rigidBody;

    private Vector3 lastPos = Vector3.zero;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ImplementMovementEffects();

        DebugControls();

        var moveHorizontal = Input.GetAxis("Horizontal");

        var movement = new Vector3(moveHorizontal * LeftRightSpeed, 0, CurrentMaxSpeed);

        _rigidBody.AddForce(movement);

        DebugOutput();
    }

    void ImplementMovementEffects()
    {
        if (InTar) CurrentMaxSpeed = 0f;
        else CurrentMaxSpeed = ForwardMaxSpeed;
    }

    void DebugControls()
    {
        if (Input.GetKey(KeyCode.Space)) CurrentMaxSpeed = AccelerationSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) CurrentMaxSpeed = -CurrentMaxSpeed;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            CurrentMaxSpeed = 0f;
            _rigidBody.velocity = Vector3.zero;
        }
    }

    void DebugOutput()
    {
        CurrentSpeed = (transform.position - lastPos).magnitude;
        lastPos = transform.position;

        CurrentVelocity = _rigidBody.velocity.magnitude;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("tar")) InTar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("tar")) InTar = false;
    }
}
