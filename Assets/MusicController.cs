using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip mainTheme;
    public AudioClip mainThemeStart;
    public AudioClip menuTheme;
    public float swellTime;
    float timer;
    bool swellingDown, swellingUp;
    public float maxVolume;

    public void ChangeToMenuTheme()
    {
        StartCoroutine(ChangeToMenu());
    }

    private void Update()
    {
        if (swellingDown)
        {
            timer += Time.deltaTime;
            GetComponent<AudioSource>().volume = (1 - timer / swellTime)*maxVolume;
            if (timer >= swellTime)
            {
                swellingDown = false;
                swellingUp = true;
                timer = 0;
            }
        }
        if(swellingUp)
        {
            timer += Time.deltaTime;
            GetComponent<AudioSource>().volume = (timer / swellTime) * maxVolume;
            if (timer >= swellTime)
            {
                swellingDown = false;
                swellingUp = false;
                timer = 0;
            }
        }
    }

    public void ChangeToMainTheme()
    {
        StartCoroutine(ChangeToMain());
    }

    IEnumerator ChangeToMain()
    {
        swellingDown = true;
        yield return new WaitForSeconds(swellTime);
        GetComponent<AudioSource>().clip = mainThemeStart;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.933f);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = mainTheme;
        GetComponent<AudioSource>().Play();
    }

    IEnumerator ChangeToMenu()
    {
        swellingDown = true;
        yield return new WaitForSeconds(swellTime);
        GetComponent<AudioSource>().clip = menuTheme;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(swellTime);
    }
}
