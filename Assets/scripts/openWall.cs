using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWall : MonoBehaviour
{
    public spawnBalls balls;
    public BoxCollider2D coll;
    [SerializeField] public int missionNumber;
    void Start()
    {
        balls = FindObjectOfType<spawnBalls>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(balls.ballscount >= 3){
               coll.isTrigger = true;
        }
        
    }
}
