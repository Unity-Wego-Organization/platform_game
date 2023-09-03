using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class TheBoxManager : MonoBehaviour
{
    public TextAsset textFile;
    public string[] textlines;

    public Text theText;
    public GameObject textBox;

    public int currentline = 0;
    public int endAtLine;
    public PlayerMovement player;

    public bool isActive;
    public bool stopPlayerMovement;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (textFile != null)
        {
            textlines = textFile.text.Split('\n');
        }
        if (endAtLine == 0)
        {
            endAtLine = textlines.Length - 1;
        }
        if (isActive)
        {
            enableTextBox();
        }
        else
        {
            disableTextBox();
        }

    }
    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        theText.text = textlines[currentline];
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            currentline += 1;
        }
        if (currentline > endAtLine)
        {
            disableTextBox();
        }
    }
    public void enableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }
    public void disableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textlines = new string[1];
            textlines = theText.text.Split("\n");
        }
    }
}
