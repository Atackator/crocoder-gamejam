using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    private Transform targetPlayer;
    public float speed;
    public float distance;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, targetPlayer.position) >= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }

        if (transform.position.x < targetPlayer.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
