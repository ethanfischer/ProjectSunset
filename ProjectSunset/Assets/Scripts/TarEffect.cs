using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarEffect : MonoBehaviour
{
    [Range(0, 5)] public float TarForwardKickback = 0.6f;
    [Range(0, 1)] public float TarForwardMaxSpeeed = 0f;

    [Range(1, 5)] public float TarHorizontalStickyness = 2.5f;
    [Range(0, 1)] public float TarHorizontalMaxSpeed = 0.25f;

    [HideInInspector] public bool inTar = false;

    private PlayerController pController;
    private DebugControls dControls;

    private void Start()
    {
        pController = GetComponent<PlayerController>();
        dControls = GetComponent<DebugControls>();
    }

    private void FixedUpdate()
    {
        //TarMechanics();
        dControls.CurrentLRSpeed = pController.LeftRightSpeed;
        dControls.CurrentMaxSpeed = pController.ForwardMaxSpeed;
    }

    private void TarMechanics()
    {
        if (!dControls.usingDebugControls && inTar)
        {
            if (dControls.CurrentLRSpeed > TarHorizontalMaxSpeed) dControls.CurrentLRSpeed /= TarHorizontalStickyness;
            else dControls.CurrentLRSpeed = TarHorizontalMaxSpeed;

            if (pController._rigidBody.velocity.z > TarForwardMaxSpeeed) dControls.CurrentMaxSpeed = -TarForwardKickback;
            else dControls.CurrentMaxSpeed = 0f;

            pController._rigidBody.velocity = new Vector3(
                pController._rigidBody.velocity.x * 0.9f,
                pController._rigidBody.velocity.y,
                pController._rigidBody.velocity.z
            );
        }
        else
        {
            dControls.CurrentLRSpeed = pController.LeftRightSpeed;
            dControls.CurrentMaxSpeed = pController.ForwardMaxSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("tar")) inTar = true;
        else inTar = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("tar")) inTar = false;
    }
}
