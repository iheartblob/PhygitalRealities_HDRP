using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [Header("Animations")]
    public Animator anim;
    public string animBoolname;

    [Header("GameObjects")]
    public GameObject[] GOEnable;
    public bool EnableGO;
    public bool DisableGO;

    [Header("Sounds")]
    public AudioSource audioSource;
    public float duration;
    public float enterVolume;
    public float exitVolume;


    void OnTriggerEnter(Collider other)
    {
        anim.SetBool(animBoolname, true);
        StopAllCoroutines();
        StartCoroutine(StartFade(audioSource, duration, enterVolume));

        if(EnableGO)
        {
            for (int i = 0; i < GOEnable.Length; i++)
            {
                GOEnable[i].SetActive(true);
            }
  
        }

        audioSource.Play();
        Debug.Log("Entered");
    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool(animBoolname, false);
        StopAllCoroutines();
        StartCoroutine(StartFadeExit(audioSource, duration, exitVolume));

        if (DisableGO)
        {
            for (int i = 0; i < GOEnable.Length; i++)
            {
                GOEnable[i].SetActive(false);
            }
        }

        Debug.Log("Exited");
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
       

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public IEnumerator StartFadeExit(AudioSource audioSource, float duration, float targetVolume)
    {
        Debug.Log("doing something");
        float currentTime = 0;
        float start = audioSource.volume;


        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        yield break;
    }
}