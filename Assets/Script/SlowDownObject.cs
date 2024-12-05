using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownObject : MonoBehaviour
{
    public float slowDownMultiplier=0.1f;
    public float slowTime = 2f;

    GameObject carGO;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        carGO = GameObject.FindGameObjectWithTag("Car");
        //StartCoroutine(slowDownTime());
        StartCoroutine(carGO.GetComponent<CarController>().slowMeDown(slowTime,slowDownMultiplier));
    }

    //IEnumerator slowDownTime()
    //{
    //    float _oldSpeed = 5f;
    //    carGO.GetComponent<CarController>().speed = _oldSpeed*slowDownMultiplier;
    //    yield return new WaitForSeconds(slowTime);
    //    carGO.GetComponent<CarController>().speed = _oldSpeed;
    //}
}
