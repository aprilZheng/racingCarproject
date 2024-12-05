using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // position in 2d direction
    public Vector2 offset;
    // component
    public Transform obj;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // create a new position, x = current position, y = offset.y + car's.y
        transform.position = new Vector3(transform.position.x, offset.y + obj.position.y,-10);
    }
}
