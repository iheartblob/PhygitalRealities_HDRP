using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBasedAnimation : MonoBehaviour
{
    public Transform Player;
    public Transform Target;
    private Animator anim;
    public Slider mySlider;
    public string AnimationName;
    // Start is called before the first frame update
    void Awake()
    {
        //mySlider = GetComponent<Slider>();
        
    }
    void Start()
    {
       // Player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        anim = GetComponent<Animator>();
        anim.Play(AnimationName);
        anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

       // Dist = Vector3.Distance(Player.transform.position, target.transform.position);
        //float dist = Vector3.Distance(Player.transform.position, Target.transform.position);
        float dist = Player.position.z - (Target.position.z - Player.position.z) * -0.1f;
        float value = dist / Target.position.z;
        mySlider.value = value;
        Debug.Log(value);
        anim.Play(AnimationName, -1, mySlider.normalizedValue);
    }
}
