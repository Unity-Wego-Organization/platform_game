using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shareposition_for_stick : MonoBehaviour
{
    [SerializeField] private GameObject stick;
    private Rigidbody2D rb;
    public stick ActiveOrDisactive;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ActiveOrDisactive = FindObjectOfType<stick>();
    }
    void Update()
    {
        if (ActiveOrDisactive.ActiveStick)
        {
            transform.position = stick.transform.position;
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f;
        }

    }

}
