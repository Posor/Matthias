using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoRaycast : MonoBehaviour
{
    public GameObject pt;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 5, Color.red);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);

        int layer_mask = LayerMask.GetMask("Default");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask, QueryTriggerInteraction.Ignore))
        {
            print(hit.transform.name + " traverse le rayon.");
            print("La distance est de " + hit.distance);
            pt.transform.position = hit.point;
        }
    }
}