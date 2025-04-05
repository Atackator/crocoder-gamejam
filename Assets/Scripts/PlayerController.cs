    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public Animator animator;
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
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) * movementSpeed));

    }
}
