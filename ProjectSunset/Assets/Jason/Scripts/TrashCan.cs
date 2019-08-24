using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    Rigidbody trashCanRB;
    public float force = 30;
    float angle;
    bool spillOnce;
    public GameObject trashPile;
    public GameObject lidGO;
    public GameObject bananaGO;
    Rigidbody lidRB;
    public Collider triggerCol;
    public AudioSource canFall;
    public AudioClip lidFly;

    void Start()
    {
        trashCanRB = GetComponent<Rigidbody>();
        lidRB = lidGO.GetComponent<Rigidbody>();
        spillOnce = true;
        angle = transform.rotation.eulerAngles.x;
    }

    private void LateUpdate()
    {
        angle = transform.rotation.eulerAngles.x;
    }

    private void Update()
    {
        if (angle > 350 && spillOnce)
        {
            spillOnce = false;
            lidRB.AddForce(transform.forward * (force * 5));
            canFall.PlayOneShot(lidFly);
            for (int i = 0; i < 2; i++)
            {
                Instantiate(trashPile, new Vector3(transform.position.x + 2f, transform.position.y +i, transform.position.z), Quaternion.identity);
            }
            //Instantiate(trashPile, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z), Quaternion.identity);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(bananaGO, new Vector3(transform.position.x + 2 + i, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trashCanRB.AddForce(transform.right * force);
            canFall.Play();
            triggerCol.enabled = false;
        }
    }

}
