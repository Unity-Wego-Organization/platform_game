using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wall_apear : MonoBehaviour
{
    public BoxCollider2D coll;
    public PlayerMovement player;
    public PlayerLife life;
    public hunt_beehavior swam;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        coll = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerMovement>();
        coll.isTrigger = true;
        life = FindObjectOfType<PlayerLife>();
        swam = FindObjectOfType<hunt_beehavior>();
    }
    public bool InField = false;
    void Update()
    {
        if (player.transform.position.x > 190f && swam.life > 0)
        {
            coll.isTrigger = false;
            InField = true;
        }  
        else
        {
            coll.isTrigger = true;
        }
        
    }


}
