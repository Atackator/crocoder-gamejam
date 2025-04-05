// using UnityEngine;
// using System.Collections.Generic;
// using System.Collections;
// using UnityEngine;

// public class Player : TimeController
// {
//     float moveSpeed = 5;
//     private Vector2 movementDirection;
//     private Animator animator;
//     void Start()
//     {
//         animator = GetComponent<Animator>();
//     }

//     public override void TimeUpdate()
//     {
//         base.TimeUpdate();

//         if (Input.GetKeyDown(KeyCode.R))
//         {
//             StartRewind();
//         }
//         if (Input.GetKeyUp(KeyCode.R))
//         {
//             StopRewind();
//         }

//         movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
//         velocity = movementDirection * moveSpeed;
//         Vector2 newPosition = (Vector2)transform.position + velocity * Time.deltaTime;
//         transform.position = newPosition;

//         if (animator != null)
//         {
//             animator.SetFloat("Speed", movementDirection.sqrMagnitude);
//         }

//         if (movementDirection.x > 0)
//             transform.localScale = new Vector3(1, 1, 1);
//         else if (movementDirection.x < 0)
//         {
//             transform.localScale = new Vector3(-1, 1, 1);
//         }
//         UpdateAnimation();
//     }
// }


// public override void TimeUpdate() {
//     base.TimeUpdate();

//     Vector2 pos = transform.position;

//     pos.y += velocity.y * Time.deltaTime;
//     velocity.y += TimeController.gravity * Time.deltaTime;

//     if (pos.y < 1)
//     {
//         pos.y = 1;
//         velocity.y = 0;
//     }

//     movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

//     animator.SetFloat("Speed", movementDirection.magnitude);
//     //animator.SetInteger()
//     if (movementDirection.x > 0)
//     {
//         transform.localScale = new Vector3(1, 1, 1);
//     }
//     else if (movementDirection.x < 0)
//     {
//         transform.localScale = new Vector3(-1, 1, 1);
//     }

//     transform.position = pos;
// }

using UnityEngine;

public class Player : TimeController
{
    public float moveSpeed = 5f;
    private Vector2 movementDirection;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void TimeUpdate()
    {
        base.TimeUpdate(); // Handles animation frame advancement and time tracking

        // 🔁 Rewind input handling
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pressed R - starting rewind");
            StartRewind();
        }

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     StartRewind();
        // }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRewind();
        }

        // ⛔ Don't accept input during rewind
        if (isRewinding) return;

        // 🔄 Movement input
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        velocity = movementDirection * moveSpeed;

        // 📍 Apply movement
        Vector2 newPosition = (Vector2)transform.position + velocity * Time.deltaTime;
        transform.position = newPosition;

        // 🕺 Animation updates
        if (animator != null)
        {
            animator.SetFloat("Speed", movementDirection.sqrMagnitude);
        }

        // ↔️ Flip sprite
        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 🎞️ Apply sampled animation
        UpdateAnimation();
    }
}
