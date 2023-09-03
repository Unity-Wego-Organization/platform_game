using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shareposition_for_bow : MonoBehaviour
{
    [SerializeField] private GameObject bow;
    private Rigidbody2D rb;
    public bow ActiveOrDisactive;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ActiveOrDisactive = FindObjectOfType<bow>();
    }
    void Update()
    {
        if (ActiveOrDisactive.ActiveBow)
        {
            transform.position = bow.transform.position;
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
            
    }

}
