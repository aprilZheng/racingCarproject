using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myfirstscript : MonoBehaviour
{
    public GameObject redCar;
    public GameObject blackCar;

    public string chosenCar;


    // Start is called before the first frame update
    void Start()
    {
        if(chosenCar == "red")
        {
            // create a copy of redCar
            GameObject.Instantiate(redCar);
        }
        else if(chosenCar == "black")
        {
            // create a copy of blackCar
            GameObject.Instantiate(blackCar);
        }
        else
        {
            Debug.Log("Sorry, no cars available.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
