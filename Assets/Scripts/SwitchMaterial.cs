using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterial : MonoBehaviour
{
    public Material[] mats;
    public bool RandomStartMaterial;
    public bool ClickThroughMaterials;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        if(RandomStartMaterial == true)
        {
            int i = Random.Range(0, mats.Length);
            Renderer rend = this.gameObject.GetComponent<Renderer>();
            Material mat = rend.material;
            mat = mats[i];
            rend.material = mats[i];
            // Debug.Log(mat);

        }

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
         {
            i++;
            if (i == mats.Length)
            {
                i = 0;
            }
            ClickEnabled();
        }
    }

    void ClickEnabled()
    {
       if(ClickThroughMaterials == true)
        {
                Renderer rend = this.gameObject.GetComponent<Renderer>();
                Material mat = rend.material;
                mat = mats[i];
                rend.material = mats[i];

       }
    }

}

