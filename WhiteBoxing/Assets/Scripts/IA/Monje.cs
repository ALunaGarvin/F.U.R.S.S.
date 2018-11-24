using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monje : MonoBehaviour {

    Collider2D col;
    Rigidbody2D rb;

    public bool asustado = false, movimiento;
    public float vel, distanciaRecorrer;
    Vector3 destination;
    public bool right = false;
    float x;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Physics2D.IgnoreCollision(collision.collider, col);
        }
    }
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        x = transform.position.x;
        destination = new Vector2(x + distanciaRecorrer, this.transform.position.y);
	}
	
	void Update () {

        if(right == true)
        {
            destination = new Vector2(x + distanciaRecorrer, this.transform.position.y);
        }
        if(right == false)
        {
            destination = new Vector2(x - distanciaRecorrer, this.transform.position.y);
        }
        if (movimiento == true) Movimientio(destination);

    }

    void Movimientio(Vector3 des)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(des.x, transform.position.y), vel);
        if (transform.position.x == des.x) right = !right;
    }
}
