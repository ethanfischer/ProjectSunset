using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private Rigidbody _rigidBody;

    void Awake()
    {
        var players = GameObject.FindObjectsOfType<Player>();
        if(players.Length > 1)
        {
            Debug.LogError("There is more than one instance of player in the game");
        }

        Instance = this; 

        _rigidBody = GetComponentInChildren<Rigidbody>();
    }

    public void Freeze()
    {
        _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Unfreeze()
    {
        _rigidBody.constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
