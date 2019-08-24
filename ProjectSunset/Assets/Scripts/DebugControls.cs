using UnityEngine;

public class DebugControls : MonoBehaviour
{
    // Just move everything back to PlayerController

    #region Vars
    #region Inspector Vars
    [Range(0, 5)] public float AccelerationSpeed = 3f;
    #endregion Inspector Vars

    #region Public Vars
    [HideInInspector] public bool usingDebugControls;

    [HideInInspector] public float CurrentMaxSpeed;
    [HideInInspector] public float CurrentSpeed;
    [HideInInspector] public float CurrentVelocity;
    [HideInInspector] public float CurrentLRSpeed;

    [HideInInspector] public Vector3 lastPos = Vector3.zero;
    #endregion Public Vars

    #region Private Vars
    private PlayerController pController;
    #endregion Private Vars
    #endregion Vars

    private void Start()
    {
        pController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        Controls();

        pController.movement = new Vector3(
            pController.moveHorizontal * CurrentLRSpeed,
            0,
            CurrentMaxSpeed
        );

        DebugOutput();
    }

    void Controls()
    {
        usingDebugControls = Input.GetKey(KeyCode.F) ||
            Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKey(KeyCode.F))
        {
            CurrentMaxSpeed = AccelerationSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentMaxSpeed = -Mathf.Abs(CurrentMaxSpeed);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            CurrentMaxSpeed = 0f;
            pController._rigidBody.velocity = new Vector3(0, pController._rigidBody.velocity.y, 0);
        }
    }

    void DebugOutput()
    {
        CurrentSpeed = (transform.position - lastPos).magnitude;
        lastPos = transform.position;

        CurrentVelocity = pController._rigidBody.velocity.magnitude;
    }
}
