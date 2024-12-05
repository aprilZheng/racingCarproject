using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // one kind of object body
    Rigidbody2D rb;

    public float speed = 1f;

    public float sMultiplier = 1f;
    public float speedIncrease = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public IEnumerator slowMeDown(float slowTime, float speedMultiplier)
    {
        sMultiplier = speedMultiplier;
        yield return new WaitForSeconds(slowTime);
        sMultiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        speed += (Time.deltaTime * speedIncrease);
        //rb.AddForce(new Vector2(0, 0.4f));
        rb.AddForce(new Vector2(0, 1 * speed * sMultiplier));
        //if(Input.GetKey(KeyCode.W))// up
        //{
        //    rb.AddForce(new Vector2(0, 1 * speed));
        //}
        if (Input.GetKey(KeyCode.A))// left
        {
            rb.AddForce(new Vector2(-1 * speed,0));
        }
        if (Input.GetKey(KeyCode.D))// right
        {
            rb.AddForce(new Vector2(1 * speed,0));
        }
    }
}
