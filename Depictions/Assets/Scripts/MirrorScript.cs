using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    //tj
    //edit made so that mirrors will fire the ray based on the parent local positon, allows new mirrors to fire ray at 90 degree angle
    public bool activated;
    public List<GameObject> activators = new List<GameObject>();

    private LineRenderer line;
    private LineRenderer otherLine;

    public AudioSource myAudioSource;
    public AudioClip loseSound;
    private bool soundPlaying;

    void Start()
    {
        soundPlaying = false;
        line = gameObject.GetComponent<LineRenderer>();
        activated = false;
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (activated)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + (transform.forward / 2), transform.parent.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawLine(transform.position + (transform.forward / 2), hit.transform.position, Color.yellow);
                //If we hit a mirror, activate that mirror.
                if (hit.transform.gameObject.layer == 9)
                {
                    Debug.DrawLine(transform.position + (transform.forward / 2), hit.transform.position, Color.yellow);
                    hit.transform.gameObject.GetComponent<MirrorScript>().activated = true;

                    if (!hit.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(transform.gameObject))
                    {
                        hit.transform.gameObject.GetComponent<MirrorScript>().activators.Add(transform.gameObject);

                        foreach (GameObject activator in activators)
                        {
                            if (!hit.transform.gameObject.GetComponent<MirrorScript>().activators.Contains(activator))
                            {
                                hit.transform.gameObject.GetComponent<MirrorScript>().activators.Add(activator);
                            }
                        }
                    }

                }

                if(hit.transform.gameObject.name == "Player")
                {
                    if (!soundPlaying)
                    {
                        myAudioSource.clip = loseSound;
                        myAudioSource.Play();
                        soundPlaying = true;
                    }


                    line.enabled = true;
                    line.useWorldSpace = true;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, hit.transform.position + Vector3.up);

                    for (int i = 0; i < activators.Count; i++)
                    {
                        otherLine = activators[i].GetComponent<LineRenderer>();

                        var increment = 1f / (activators.Count + 1f);


                        otherLine.startColor = new Color(1, 0, 0, 1 - increment * i);
                        otherLine.endColor = new Color(1, 0, 0, 1 - increment * i);

                        otherLine.enabled = true;
                        otherLine.useWorldSpace = true;
                        otherLine.SetPosition(0, activators[i].transform.position);

                        if(i != 0)
                        {
                            otherLine.SetPosition(1, activators[i - 1].transform.position);
                        }
                        else
                        {
                            otherLine.SetPosition(1, transform.position);
                        }

                    }
                }
            }
            activated = false;
        }
    }
}
