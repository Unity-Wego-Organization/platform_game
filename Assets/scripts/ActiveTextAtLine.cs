using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTextAtLine : MonoBehaviour
{
    public TextAsset theText;
    public int startLine;
    public int endLine;
    public TheBoxManager theTextBox;
    public PlayerMovement player;
    public bool destroyWhenActivated;
    public bool requireButtonPress;
    private bool waitForPress;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        theTextBox = FindObjectOfType<TheBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E) && player.canTalk == true)
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentline = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.enableTextBox();
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name== "player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            else
            {
                theTextBox.ReloadScript(theText);
                theTextBox.currentline = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.enableTextBox();
                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            waitForPress = false;
        }
    }
}
