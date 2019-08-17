using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tar_Patch : MonoBehaviour
{
    MeshCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) print("player in tar pit");
    }
}
