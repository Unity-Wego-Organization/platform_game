using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fly_fish : MonoBehaviour
{
    private Rigidbody2D rb;
    public BoxCollider2D coll;
    private bool boat;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.isTrigger = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.3f || transform.position.x < 66f)
        {
            transform.position = new Vector2(Random.Range(75, 130), 0.31f);
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(Random.Range(-7f, -10f), Random.Range(5.0f, 12.0f));
        }
        if (transform.position.y > 2.2f)
        {
            coll.isTrigger = false;
        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boats"))
        {
            coll.isTrigger = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boats"))
        {
            coll.isTrigger = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boats"))
        {
            coll.isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boats"))
        {
            coll.isTrigger = true;
        }
    }
}