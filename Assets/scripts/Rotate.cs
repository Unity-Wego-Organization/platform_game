using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float Speed = 2f;
    private void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);
    }
}
