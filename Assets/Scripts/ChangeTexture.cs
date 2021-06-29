using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeTexture : MonoBehaviour
{
    public Texture2D Sample1;

    public Texture2D Sample2;
    public Texture2D Sample3;
    public string tag;
    //public string structure;

    // Start is called before the first frame update
    public void change1()
    {

        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag(tag))
        {
            //Do something to ObjectFound, like this:
            //    ObjectFound.GetComponent<Renderer>().material = mat;
            ObjectFound.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Sample1);

        }
    }
    public void change2()
    {
        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag(tag))
        {
            //Do something to ObjectFound, like this:
            //    ObjectFound.GetComponent<Renderer>().material = mat;
            ObjectFound.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Sample2);

        }

    }

    public void change3()
    {
        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag(tag))
        {
            //Do something to ObjectFound, like this:
            //    ObjectFound.GetComponent<Renderer>().material = mat;
            ObjectFound.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Sample3);

        }

    }

}
