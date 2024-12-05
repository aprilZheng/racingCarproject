using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _go = GameObject.FindGameObjectWithTag("UI");
        _go.GetComponent<UIController>().livesLeft -= 1;
        _go.GetComponent<UIController>().UpdateLives();
        Destroy(this.gameObject);
    }
}
