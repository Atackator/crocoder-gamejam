using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    void Flip() {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * movementSpeed;

    }
}
