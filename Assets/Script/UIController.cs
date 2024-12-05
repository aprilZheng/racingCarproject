using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public float counter = 0f;
    public TextMeshProUGUI timerTxt;

    public GameObject warningOne;
    public GameObject warningTwo;
    public GameObject warningThree;

    public GameObject deathPanel;
    public TextMeshProUGUI statsText;
    public int livesLeft = 3;

    string minutes;
    string seconds;

    private void Start()
    {
        livesLeft = 3;
        UpdateLives();
    }

    public void UpdateLives()
    {
        if(livesLeft<=2)
        {
            warningOne.SetActive(true);
        }
        else
        {
            warningOne.SetActive(false);
        }
        if(livesLeft<=1)
        {
            warningTwo.SetActive(true);
        }
        else
        {
            warningTwo.SetActive(false);
        }
        if(livesLeft<=0)
        {
            warningThree.SetActive(true);
        }
        else
        {
            warningThree.SetActive(false);
        }

        if (livesLeft < 0)
        {
            // restart the level when we have lost our 3 lives
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            minutes = Mathf.Floor(counter / 60f).ToString();
            seconds = (counter % 60f).ToString("00");

            string timeFormatted = "Time Taken: " +minutes + " m " + seconds + " s";
            if (minutes == "0") { timeFormatted = "Time Taken: " + seconds + " s"; }

            deathPanel.SetActive(true);

            int score = Mathf.RoundToInt(counter * GameObject.FindGameObjectWithTag("Car").transform.position.y);
            statsText.text = "Distance Travelled: " + Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Car").transform.position.y) + " m\n"+timeFormatted+"\nScore: "+score.ToString();

            // warningOne's panel = warningOne.transfoem.parent
            warningOne.transform.parent.gameObject.SetActive(false);

            GameObject.FindGameObjectWithTag("Car").GetComponent<CarController>().enabled = false;
            GameObject.FindGameObjectWithTag("Car").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Car").GetComponent<AudioSource>().enabled = false;

            foreach(GameObject _g in GameObject.FindGameObjectsWithTag("DisableOnLevelEnd"))
            {
                _g.SetActive(false);
            }
        }
        else
        {
            deathPanel.SetActive(false);
            warningOne.transform.parent.gameObject.SetActive(true);

            GameObject.FindGameObjectWithTag("Car").GetComponent<CarController>().enabled = true;
            GameObject.FindGameObjectWithTag("Car").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.FindGameObjectWithTag("Car").GetComponent<AudioSource>().enabled = true;
        }
    }

    public void RetryButtonPressed()
    {
        // reload the scene, both lines will do the same job
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainLevel");
    }

    public void ExitButtonPressed()
    {
        // go to the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        counter += Time.deltaTime;

        minutes = Mathf.Floor(counter / 60f).ToString("00");
        seconds = (counter % 60f).ToString("00");
        timerTxt.text = minutes+":"+seconds;
    }
}
