using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterScript : MonoBehaviour
{
    public Light lightToFade;
    public float eachFadeTime = 2f;
    public float fadeWaitTime = 5f;

    public float minimumLuminosity;
    public float maximumLuminosity;


    public bool fadeIn; //true makes fade in, false fades out 

    public AudioSource globalAudioSource; 
    public AudioClip backgroundTrack1;
    public AudioClip backgroundTrack2;

    public float musicFadeDuration;
    public float musicFadeTargetVolume;

    public AudioClip enterChime; 
    AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        // StartCoroutine(fadeInAndOut(lightToFade, fadeIn, fadeWaitTime));
    }

    void OnTriggerEnter (Collider other) {
        
        if (other.tag == "Player")
        {
            fadeIn = false; 

            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(enterChime, 1.0F);

          //  StartCoroutine(FadeAudioSource.StartFade(globalAudioSource, musicFadeDuration, musicFadeTargetVolume));
            StartCoroutine(fadeInAndOut(lightToFade, fadeIn, fadeWaitTime));
            globalAudioSource.volume = 1;
            globalAudioSource.clip = backgroundTrack2; 
            globalAudioSource.Play();


        }
        
       // StartCoroutine(fadeInAndOut(lightToFade, fadeIn, fadeWaitTime));

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
          

        }

     //   if (other.tag == "Player")
    //    {
     //       StartCoroutine(fadeInAndOut(lightToFade, fadeIn, fadeWaitTime));

      //  }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fadeIn = true; 
            StartCoroutine(fadeInAndOut(lightToFade, fadeIn, fadeWaitTime));
            globalAudioSource.volume = 1;
            globalAudioSource.clip = backgroundTrack1; 
            globalAudioSource.Play();


        }
    }
    IEnumerator fadeInAndOut(Light lightToFade, bool fadeIn, float duration)
    {
        float minLuminosity = minimumLuminosity; // min intensity
        float maxLuminosity = maximumLuminosity; // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
        }

        float currentIntensity = lightToFade.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);

            yield return null;
        }

    }

    public static class FadeAudioSource
    {

        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
