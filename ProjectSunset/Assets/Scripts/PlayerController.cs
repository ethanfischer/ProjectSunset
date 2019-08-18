using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Vars
    #region Public Vars
    public float LeftRightSpeed = 1.5f;
    public float ForwardMaxSpeed = 0.7f;
    [Range(0, 3)] public float AccelerationSpeed = 3f;
    [Range(0, 5)] public float TarForwardStickyness = 0.5f;
    [Range(1, 5)] public float TarHorizontalStickyness = 2f;
    #endregion Public Vars

    #region Private Vars
    private bool InTar = false;
    private float CurrentMaxSpeed;
    private float CurrentSpeed;
    private float CurrentVelocity;
    private float CurrentLRSpeed;

    private Rigidbody _rigidBody;

    private Vector3 lastPos = Vector3.zero;
    #endregion Private Vars
    #endregion Vars

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        CurrentLRSpeed = LeftRightSpeed;
    }

    void FixedUpdate()
    {
        ImplementMovementEffects();

        DebugControls();

        MovePlayer();

        DebugOutput();
    }

    private void MovePlayer()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var movement = Vector3.zero;

        if (InTar)
        {
            if (CurrentLRSpeed > 0.4f) CurrentLRSpeed /= TarHorizontalStickyness;
            else CurrentLRSpeed = 0.4f;

            _rigidBody.velocity = new Vector3(
                _rigidBody.velocity.x * 0.9f,
                _rigidBody.velocity.y,
                _rigidBody.velocity.z
            );

            movement = new Vector3(moveHorizontal * CurrentLRSpeed, 0, CurrentMaxSpeed);
        }
        else
        {
            CurrentLRSpeed = LeftRightSpeed;
            movement = new Vector3(moveHorizontal * CurrentLRSpeed, 0, CurrentMaxSpeed);
        }

        _rigidBody.AddForce(movement);
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
            _rigidBody.velocity = new Vector3(0, _rigidBody.velocity.y, 0);
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
