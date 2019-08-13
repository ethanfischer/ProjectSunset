using UnityEngine;

public static class BallExtensions
{
    public static bool IsBall(this Collider collider)
    {
        return collider.GetComponent<Ball>();
    }
}
