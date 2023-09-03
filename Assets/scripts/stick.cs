using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlayerMovement player;
    public activeStick sus;
    public bool ActiveStick = false;
    private bool DeactiveStick = true;
    [SerializeField] public GameObject onFloor;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        sus = FindObjectOfType<activeStick>();
    }
    void Update()
    {
        if (sus.waitForPress && Input.GetKeyDown(KeyCode.Q) && DeactiveStick && !ActiveStick)
        {
            ActiveStick = true;
            DeactiveStick = false;
        }

        if (ActiveStick)
        {
            player.isHolding = true;
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
            if (player.sprite.flipX)
            {
                transform.position = new Vector2(player.transform.position.x - 0.5f, player.transform.position.y + 2f);
            }
            else
            {
                transform.position = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y + 2f);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                DeactiveStick = true;
            }
            if (Input.GetKeyDown(KeyCode.Q) && DeactiveStick)
            {
                ActiveStick = false;
                player.isHolding = false;
            }
        }
        else
        {
            transform.position = onFloor.transform.position;
        }

    }

}

