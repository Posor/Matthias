using UnityEngine;
using System.Collections;


public class Interactionobjet : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;


    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist <= 1.9f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }


            if (Input.GetKey(KeyCode.P))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}