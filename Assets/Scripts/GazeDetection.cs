using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeDetection : MonoBehaviour
{
    [Header("Basic Attributes")]
    GameObject hitObj;
    [SerializeField]
    public string MaskName;
    public int GazeLength;
    private bool hitFlag;

    public Color OGColor;
    public Color selectedColor;

    [Header("Animations")]
    public string animation;
    public Animator Anim;

    [Header("Sounds")]
    public AudioSource audio;

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        LayerMask mask = LayerMask.GetMask(MaskName);

        RaycastHit hit;

        // Check for mouse click / hit 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        {
            StartCoroutine("GazeDetected");

            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < 1; i++)

                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    hitObj = hit.transform.gameObject;
                    Destroy(hitObj);
                }

            }
            else
            {

                hitObj = hit.transform.gameObject;

                OGColor = hitObj.GetComponent<Renderer>().material.GetColor("_BaseColor");
                //          hitObj.GetComponent<Renderer>().material.SetColor("_BaseColor", selectedColor);
            }
            hitFlag = true;
        }
        else if (hitFlag)
        {
            hitFlag = false;
            //         hitObj.GetComponent<Renderer>().material.SetColor("_BaseColor", OGColor);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }


    }

    public void DestroyCollided()
    {
        Destroy(hitObj);
    }

    public void triggerAnimation()
    {
        Anim.SetBool("AnimationBool", true);
    }

    public void playSound()
    {
        if (audio.isPlaying)
        {
            return;
        }
        else
        {
            audio.Play();
        }

    }

    IEnumerator GazeDetected()
    {
        yield return new WaitForSeconds(GazeLength);

        if (hitFlag == true)
        {
            triggerAnimation();
            //DestroyCollided();
        }

    }



}

