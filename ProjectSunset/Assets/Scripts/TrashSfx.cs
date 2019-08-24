using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSfx : MonoBehaviour
{
    private static TrashSfx _instance;
    public static TrashSfx Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<TrashSfx>();
            }

            return _instance;
        }
    }

    public AudioSource AudioSource;

    public void Play()
    {
        AudioSource.Play();
    }
}
