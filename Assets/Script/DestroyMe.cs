using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is to destroy the road we have spawned but we wont see it again, because it will become very big when the time going if we dont destroy it

public class DestroyMe : MonoBehaviour
{
    public GameObject carObj;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // if the current object(road) y level is low than the car object y level - 10
        if(this.transform.position.y < carObj.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
