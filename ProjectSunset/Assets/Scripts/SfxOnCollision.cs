using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxOnCollision : MonoBehaviour
{
    private TrashSfx trashSfx;
    void Start()
    {
    }

    void OnCollisionEnter()  
    {
        trashSfx.Play();
    }
}
