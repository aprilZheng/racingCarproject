using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitAudio : MonoBehaviour
{
    public AudioClip objectHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioController>().PlayAudio(objectHit);
    }
}
