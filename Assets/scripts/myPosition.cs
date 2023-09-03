using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPosition : MonoBehaviour
{
    public SwitchingScene scene;
    [SerializeField] private Vector3 goWhere;
    void Start()
    {
        scene = FindObjectOfType<SwitchingScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scene.GoingLocation = goWhere;
    }
}
