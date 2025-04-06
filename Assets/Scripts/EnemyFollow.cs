// using UnityEngine;
// using System.Collections.Generic;
// using System.Collections;

// public class EnemyFollow : MonoBehaviour
// {
//     private Transform targetPlayer;
//     public float speed;
//     public float distance;

//     void Start()
//     {
//         targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
//     }

//     void Update()
//     {
//         if (Vector2.Distance(transform.position, targetPlayer.position) >= distance)
//         {
//             transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
//         }

//         if (transform.position.x < targetPlayer.position.x)
//         {
//             transform.localScale = new Vector3(-1, 1, 1);
//         }
//         else 
//         {
//             transform.localScale = new Vector3(1, 1, 1);
//         }
//     }


using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform targetPlayer;
    public float speed;
    public float distance;

    // Offset from the center to the feet in world units
    public float feetYOffset = 0.32f; // You can tweak this in the Inspector

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            targetPlayer = playerObj.transform;
        }
    }

    void Update()
    {
        if (targetPlayer == null) return;

        // Get the estimated position of the player's feet
        Vector3 playerFeetPos = targetPlayer.position + new Vector3(0, -feetYOffset, 0);

        if (Vector2.Distance(transform.position, playerFeetPos) >= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerFeetPos, speed * Time.deltaTime);
        }

        // Flip based on feet position
        if (transform.position.x < playerFeetPos.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
