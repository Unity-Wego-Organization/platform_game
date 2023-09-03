using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class bow : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlayerMovement player;
    public bool ActiveBow = false;
    public bool DeactiveBow = true;
    private bool waitForPress;
    private BoxCollider2D coll;
    public Vector2 direction;
    


    [SerializeField] public GameObject onFloor;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            waitForPress = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            waitForPress = false;
        }
    }


    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        direction = MousePos - bowPos;
        
        if (waitForPress && Input.GetKeyDown(KeyCode.Q) && DeactiveBow && !ActiveBow)
        {
            ActiveBow = true;
            DeactiveBow = false;
        }

        if (ActiveBow)
        {
            player.isHolding = true;
            FaceMouse();
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -3f);
            if (Input.GetKeyUp(KeyCode.Q))
            {
                DeactiveBow = true;
            }
            if (Input.GetKeyDown(KeyCode.Q) && DeactiveBow)
            {
                ActiveBow = false;
                player.isHolding = false;
            }
        }
        else
        {
            transform.position = onFloor.transform.position;
        }
    }
    void FaceMouse()
    {
        transform.right = direction;
    }
}
