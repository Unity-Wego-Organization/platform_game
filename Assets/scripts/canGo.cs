using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canGo : MonoBehaviour
{
    public bool waitForPress;
    public BoxCollider2D coll;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
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
}
