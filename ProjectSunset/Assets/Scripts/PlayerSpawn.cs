using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private static PlayerSpawn _instance;
    public static PlayerSpawn Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerSpawn>();
            }

            return _instance;
        }
    }

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Player.Instance.Ball.transform.position = transform.position;
    }
}
