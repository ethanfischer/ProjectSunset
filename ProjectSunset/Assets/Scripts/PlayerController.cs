using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float LeftRightSpeed = 1.5f;
    public float ForwardMaxSpeed = 0.7f;
    [Range(0, 3)] public float AccelerationSpeed = 3f;
    [Range(0, 5)] public float TarForwardStickyness = 0.5f;
    [Range(0, 5)] public float TarHorizontalStickyness = 0.3f;

    private bool InTar = false;
    private float CurrentMaxSpeed;
    private float CurrentSpeed;
    private float CurrentVelocity;
    private float CurrentLRSpeed;

    private Rigidbody _rigidBody;

    private Vector3 lastPos = Vector3.zero;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        CurrentLRSpeed = LeftRightSpeed;
    }

    void FixedUpdate()
    {
        ImplementMovementEffects();

        DebugControls();

        var moveHorizontal = Input.GetAxis("Horizontal");

        var movement = Vector3.zero;

        if (InTar)
        {
            if (CurrentLRSpeed > TarHorizontalStickyness) CurrentLRSpeed /= TarHorizontalStickyness;
            else CurrentLRSpeed = TarHorizontalStickyness;
            movement = new Vector3(moveHorizontal * CurrentLRSpeed, 0, CurrentMaxSpeed);
        }
        else
        {
            CurrentLRSpeed = LeftRightSpeed;
            movement = new Vector3(moveHorizontal * CurrentLRSpeed, 0, CurrentMaxSpeed);
        }

        _rigidBody.AddForce(movement);

        DebugOutput();
    }

    void ImplementMovementEffects()
    {
        if (InTar)
        {
            if (_rigidBody.velocity.z > 0.25f) CurrentMaxSpeed = -TarForwardStickyness;
            else CurrentMaxSpeed = 0f;
        }
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
