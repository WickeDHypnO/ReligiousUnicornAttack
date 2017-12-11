using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioClip mainThemeStart;
    public AudioClip menuTheme;
    public float maxVolume;
    public float swellTime;
    private float timer;
    private bool swellingDown, swellingUp;

    //Start changing music to Menu theme
    public void ChangeToMenuTheme()
    {
        StartCoroutine(ChangeToMenu());
    }

    //Start changing music to Game theme
    public void ChangeToMainTheme()
    {
        StartCoroutine(ChangeToMain());
    }

    private void Update()
    {
        if (swellingDown)
        {
            //Swell volume down to avoid sudden music changes
            timer += Time.deltaTime;
            GetComponent<AudioSource>().volume = (1 - timer / swellTime)*maxVolume;
            if (timer >= swellTime)
            {
                swellingDown = false;
                swellingUp = true;
                timer = 0;
            }
        }
        if (swellingUp)
        {
            //Swell volume up with new music
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

    //Coroutine changing to Main theme
    private IEnumerator ChangeToMain()
    {
        swellingDown = true;
        yield return new WaitForSeconds(swellTime);
        //Play intro to Main theme
        GetComponent<AudioSource>().clip = mainThemeStart;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.933f);
        //Switch to Main theme after playing intro
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = mainTheme;
        GetComponent<AudioSource>().Play();
    }

    //Coroutine changing to Menu theme
    private IEnumerator ChangeToMenu()
    {
        swellingDown = true;
        yield return new WaitForSeconds(swellTime);
        GetComponent<AudioSource>().clip = menuTheme;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(swellTime);
    }
}
