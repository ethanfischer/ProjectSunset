using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float LeftRightSpeed;
    public float ForwardMaxSpeed;

    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var movement = new Vector3(moveHorizontal * LeftRightSpeed, 0, ForwardMaxSpeed);

        _rigidBody.AddForce(movement);
    }
}
