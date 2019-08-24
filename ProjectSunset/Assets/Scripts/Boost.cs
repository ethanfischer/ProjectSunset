using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [Range(1f, 100f)] public float boostSpeed;
    [Range(0f, 0.1f)] public float boostDuration;
    [Range(0f, 5f)] public float boostCooldown;

    private bool boostOnCooldown = false;
    private float currentBoostCount = Mathf.Epsilon;

    private PlayerController pController;
    private DebugControls dControls;
    private TarEffect tEffect;

    // Start is called before the first frame update
    void Start()
    {
        pController = GetComponent<PlayerController>();
        dControls = GetComponent<DebugControls>();
        tEffect = GetComponent<TarEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        BoostMechanics();
    }

    private void BoostMechanics()
    {
        bool boosted = Input.GetKeyDown(KeyCode.Space);

        if (boosted && !boostOnCooldown)
        {
            boostOnCooldown = true;
            pController.movement.z *= boostSpeed;
        }

        if (boostOnCooldown && !tEffect.inTar)
        {
            if (currentBoostCount > boostCooldown)
            {
                boostOnCooldown = false;
                currentBoostCount = Mathf.Epsilon;
            }

            currentBoostCount += Time.deltaTime;
        }
    }
}
