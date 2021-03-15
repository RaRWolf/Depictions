using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit1;
        if (Physics.Raycast(transform.position + (transform.forward) + transform.up, Vector3.forward, out hit1, Mathf.Infinity))
        {
            if (hit1.transform.gameObject.layer == 9)
            {
                hit1.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                if (!hit1.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                {
                    hit1.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);
                }
            }
        }

        RaycastHit hit2;
        if (Physics.Raycast(transform.position - (transform.forward) + transform.up, -Vector3.forward, out hit2, Mathf.Infinity))
        {
            if (hit2.transform.gameObject.layer == 9)
            {
                hit2.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                if (!hit2.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                {
                    hit2.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);
                }
            }
        }

        RaycastHit hit3;
        if (Physics.Raycast(transform.position + (transform.right) + transform.up, Vector3.right, out hit3, Mathf.Infinity))
        {
            if (hit3.transform.gameObject.layer == 9)
            {
                hit3.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                if (!hit3.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                {
                    hit3.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);
                }
            }
        }

        RaycastHit hit4;
        if (Physics.Raycast(transform.position - (transform.right) + transform.up, -Vector3.right, out hit4, Mathf.Infinity))
        {
            if (hit4.transform.gameObject.layer == 9)
            {
                hit4.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                if (!hit4.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                {
                    hit4.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);
                }
            }
        }
    }
}
