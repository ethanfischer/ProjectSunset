using UnityEngine;

public static class PlayerExtensions
{
    public static bool IsPlayer(this Collider collider)
    {
        return collider.GetComponentInParent<Player>();
    }
}
