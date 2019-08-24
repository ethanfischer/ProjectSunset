using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float LeftRightSpeed;
    public float ForwardMaxSpeed;

    [HideInInspector] public float moveHorizontal;
    [HideInInspector] public Vector3 movement;
    [HideInInspector] public Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        GetHorizontalInput();
        MovePlayer();
    }

    private void GetHorizontalInput() { moveHorizontal = Input.GetAxis("Horizontal"); }
    private void MovePlayer() { _rigidBody.AddForce(movement); }
}