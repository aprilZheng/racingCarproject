using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip backgroundAudio;
    public AudioClip[] uiButtonAudio;

    [Range(0,1)]
    public float volume = 0.1f;

    private void Start()
    {
        PlayAudio(backgroundAudio, true, false, true);
        GameObject.FindGameObjectWithTag("Car").GetComponent<AudioSource>().volume = volume;
    }

    public void PlayAudio(AudioClip _clip, bool loops = false, bool persist = false, bool disableOnLevelEnd = false)
    {
        GameObject go = new GameObject();
        go.AddComponent<AudioSource>();
        go.GetComponent<AudioSource>().clip = _clip;
        go.GetComponent<AudioSource>().loop = loops;
        go.GetComponent<AudioSource>().volume = volume;
        go.GetComponent<AudioSource>().Play();

        if (persist) // if we change scene, the object will stay
        {
            DontDestroyOnLoad(go);
        }

        if(disableOnLevelEnd)
        {
            go.tag = "DisableOnLevelEnd";
        }
    }

    public void PlayUIAudioButtonPressed()
    {
        AudioClip _c = uiButtonAudio[Random.Range(0, uiButtonAudio.Length)];
        PlayAudio(_c,false,true);
    }
}
