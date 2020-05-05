using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class przeciwnik : virtualclass
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 change;

    void speedChange()
    {
        float newSpeed = 2;
        speed = newSpeed;
    }

    void wypadanieExpa() { }
    void preAtak()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Atak() 
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        change = Vector3.zero;
    }

    private void Start()
    {
        speedChange();
        preAtak();
    }

    private void Update()
    {
        Atak();    
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

 
}
