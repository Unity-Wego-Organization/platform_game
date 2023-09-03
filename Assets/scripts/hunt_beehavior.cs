using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;

public class hunt_beehavior : MonoBehaviour
{

    private Rigidbody2D rb;
    public BoxCollider2D coll;
    private Animator amin;
    public SpriteRenderer sprite;
    [SerializeField] public GameObject player;
    public wall_apear wall;
    public Arrow arrow;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        wall = FindObjectOfType<wall_apear>();
        arrow = FindObjectOfType<Arrow>();
    }
    private bool alreadyRunning = false;
    private bool lockIn = false;
    private bool stop = false;
    int motion = 0;
    float dx = 10;
    [SerializeField] public int life = 7;
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 10f)
        {
            if (!lockIn)
            {
                StartCoroutine(Angry());
                lockIn = true;
            }
        }
        else
        {
            if (motion == 0)
            {

                rb.velocity = new Vector2(5f, rb.velocity.y);
            }
            else if (motion == 1)
            {
                rb.velocity = new Vector2(-5f, rb.velocity.y);
            }
            else if (motion == 2)
            {
                motion = Random.Range(0, 1);
            }
            else if (motion == 3)
            {
                rb.velocity = new Vector2(dx, rb.velocity.y);
                if (rb.velocity.x > 0)
                {
                    dx -= 0.01f;
                }
                else
                {
                    dx += 0.01f;
                }

            }

            if (!alreadyRunning)
            {
                StartCoroutine(waitAround());
            }
        }
        if (rb.velocity.x > 0.1 || rb.velocity.x < -0.1)
        {
            if (rb.velocity.x > 0)
            {
                sprite.flipX = true;
            }
            else if (rb.velocity.x < 0)
            {
                sprite.flipX = false;
            }
        }
        AminationUpdate();
    }
    private IEnumerator waitAround()
    {
        alreadyRunning = true;
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        if (Random.Range(1, 4) == 1)
        {
            stop = true;
            dx = rb.velocity.x;
            motion = 3;
            yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));
            stop = false;
            dx = rb.velocity.x;
            motion = Random.Range(0, 1);
        }
        if (Random.Range(1, 4) == 2)
        {
            motion = 2;
        }
        alreadyRunning = false;
    }


    private IEnumerator Angry()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        if (player.transform.position.x - transform.position.x > 0)
        {
            rb.velocity = new Vector2(25f, 3f);
        }
        else
        {
            rb.velocity = new Vector2(-25f, 3f);
        }
        yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
        motion = Random.Range(0, 1);
        lockIn = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "p1")
        {
            motion = 0;
        }
        else if (collision.gameObject.name == "p2")
        {
            motion = 1;
        }
        else if (collision.gameObject.CompareTag("arrow"))
        {
            life -= 1;
        }
    }

    private enum MovementState { idle, running, jumping, falling, holding }

    private void AminationUpdate()
    {
        MovementState state;
        state = MovementState.idle;
        amin.SetInteger("state", (int)state);
    }
}
