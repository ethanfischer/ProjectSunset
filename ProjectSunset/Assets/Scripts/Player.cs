using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
<<<<<<< HEAD
=======
    public GameObject Ball;
    private Rigidbody _rigidBody;
>>>>>>> 6dd84433437a485e0b3a8a65cf97ae2fd537a34c

    void Awake()
    {
        var players = GameObject.FindObjectsOfType<Player>();
        if(players.Length > 1)
        {
            Debug.LogError("There is more than one instance of player in the game");
        }

<<<<<<< HEAD
        Instance = this;
=======
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
>>>>>>> 6dd84433437a485e0b3a8a65cf97ae2fd537a34c
    }

    // Update is called once per frame
    void Update()
    {

    }
}
