using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float speed;
    GameObject testScriptsGO;
    AudioSource pickUpAS;

    private void Start()
    {
        testScriptsGO = GameObject.Find("TestScripts"); //This is where the AudioSource lives
        pickUpAS = testScriptsGO.GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickUpAS.Play();
            Destroy(this.gameObject);
        }
    }
}
