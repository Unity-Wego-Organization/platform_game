using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
    private int strawberries=0;
    [SerializeField] private Text StrawberriesText;
    [SerializeField] private AudioSource collect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            strawberries++;
            StrawberriesText.text = "Strawberries: " + strawberries;
        }
    }
}
