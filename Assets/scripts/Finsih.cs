using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finsih : MonoBehaviour
{
    private AudioSource finish;
    private bool levelcompleted = false;
    private void Start()
    {
        finish = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" && levelcompleted==false)
        {
            levelcompleted = true;
            finish.Play();
            Invoke("completelevel", 2f);
        }
    }

    private void completelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
