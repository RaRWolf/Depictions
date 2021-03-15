using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.layer == 9)
            {
                hit.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                if (!hit.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                {
                    hit.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);
                }
            }
        }
    }
}
