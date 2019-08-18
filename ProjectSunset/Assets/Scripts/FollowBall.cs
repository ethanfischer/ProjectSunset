using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public GameObject Ball;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Ball.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Ball.transform.position + _offset;
    }
}
