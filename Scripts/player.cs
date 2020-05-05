using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : virtualclass
{
    public float level = 0;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        preRuch();
    }

    // Update is called once per frame
    void Update()
    {
        Ruch();
    }

    void preRuch()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Ruch()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter(speed);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter(float speed)
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }

}
