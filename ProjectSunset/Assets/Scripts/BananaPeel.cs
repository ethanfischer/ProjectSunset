using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    public int MinimumSlipFactor = 10;
    public int MaximumSlipFactor = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            SendBallInRandomDirection(other);
        }
    }

    private void SendBallInRandomDirection(Collider other)
    {
        var rigidBody = other.GetComponent<Rigidbody>();
        var randomizedSlipFactor = GetRandomizedSlipFactor();
        var leftOrRightFactor = GetLeftOrRightFactor();
        rigidBody.AddForce(new Vector3(randomizedSlipFactor * leftOrRightFactor, 0, 0));
    }

    private int GetRandomizedSlipFactor()
    {
        return Random.Range(MinimumSlipFactor, MaximumSlipFactor);
    }

    private int GetLeftOrRightFactor()
    {
        //Returns 1 or -1
        return Random.Range(0, 2) * 2 - 1;
    }
}
