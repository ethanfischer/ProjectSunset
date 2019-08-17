using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance; 

    void Awake()
    {
        var players = GameObject.FindObjectsOfType<Player>();
        if(players.Length > 1)
        {
            Debug.LogError("There is more than one instance of player in the game");
        }

        Instance = this; 
    }

    public void StopRolling()
    {
        var rigidBody = GetComponentInChildren<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
