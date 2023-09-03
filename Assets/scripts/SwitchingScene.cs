using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingScene : MonoBehaviour
{
    private bool waitForPress;
    public Vector3 GoingLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("doors"))
        {
            waitForPress = true;
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("doors"))
        {
            waitForPress = false;
        }
    }
    private void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            //SceneManager.LoadScene(sceneGoing);
            //respawnpoint = transform.position;
            transform.position= GoingLocation;


        }
    }

}
