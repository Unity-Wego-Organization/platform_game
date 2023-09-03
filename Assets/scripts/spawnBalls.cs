using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class spawnBalls : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 orginalLocation;
    public BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public canGo balls;
    // Start is called before the first frame update
    void Start()
    {
        orginalLocation = transform.position;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        balls = FindObjectOfType<canGo>();
    }

    private bool canJump = true;
    private bool go = false;
    // Update is called once per frame
    void Update()
    {
        if (canJump && go && balls.waitForPress)
        {
            transform.position = orginalLocation;
            StartCoroutine(Jump());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            go = true;
        }
        else
        {
            go = false;
        }
    }
    private IEnumerator Jump()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        canJump = false;
        float originalGravity = rb.gravityScale;
        rb.velocity = new Vector2(rb.velocity.x + Random.Range(-5f, 5f), 15f);
        yield return new WaitForSeconds(1f);
        rb.gravityScale = originalGravity;
        canJump = true;
    }
    public int ballscount;
    bool touched = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "stick" && !touched)
        {
            rb.velocity = new Vector2(rb.velocity.x + Random.Range(-5f, 5f), 10f);
            ballscount++;
            touched = true;
        }
        if (collision.gameObject.name == "p1")
        {
            coll.isTrigger = true;
        }
        if (collision.gameObject.name == "p2")
        {
            coll.isTrigger = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "stick")
        {
            touched = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "p1")
        {
            coll.isTrigger = true;
        }
        if (collision.gameObject.name == "p2")
        {
            coll.isTrigger = false;
        }
        if (collision.gameObject.name != "pipe")
        {
            transform.position = orginalLocation;
            rb.bodyType = RigidbodyType2D.Static;
        }  
    }
}
