using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	public Sprite fallenSprite;

    // when the car hit the item, it falls
    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(waitForSeconds());
       //foreach(PolygonCollider2D _col in GetComponents<PolygonCollider2D>())
       // {
       //     _col.enabled = false;
       // }

       // GetComponent<SpriteRenderer>().sprite = fallenSprite;
    }

    IEnumerator waitForSeconds()
    {
        // let the item stop for a short time before the car hits it
        yield return new WaitForSeconds(0.1f);

        foreach(PolygonCollider2D _col in GetComponents<PolygonCollider2D>())
        {
            _col.enabled = false;
        }

        GetComponent<SpriteRenderer>().sprite = fallenSprite;
    }
}
