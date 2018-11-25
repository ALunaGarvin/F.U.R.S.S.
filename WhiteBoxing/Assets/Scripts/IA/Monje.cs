using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monje : MonoBehaviour {

    Collider2D col;
    Rigidbody2D rb;
    public SpriteRenderer spr;
    public Constrol player;

    public bool  movimiento;
    public float vel, distanciaRecorrer, huir;
    public Animator anim;
    Vector3 destination;
    public bool asustado = false, right = false, pierde = false;
    float x;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Physics2D.IgnoreCollision(collision.collider, col);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pierde != true)
        {
            transform.localScale = new Vector2(1, 1);
            if (collision.transform.tag == "Murcielago")
            {
                asustado = true;
                Vector2 movDirc = new Vector2(transform.position.x - collision.transform.position.x, 0);

                transform.Translate(movDirc.normalized * huir * Time.deltaTime);
                if (movDirc.normalized.x < 0)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
            }
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.Play("aigua monjo");
            pierde = true;
            this.gameObject.GetComponent<Monje>().enabled = false;
        }
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Murcielago")
        {
            asustado = false;
        }
    }
    void Start () {
        anim = GetComponent<Animator>();
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        x = transform.position.x;
        destination = new Vector2(x + distanciaRecorrer, this.transform.position.y);
	}
	
	void Update () {

        if(pierde != true) {
            if (asustado == false)
            {
                if (right == true)
                {
                    transform.localScale = new Vector2(1, 1);
                    destination = new Vector2(x + distanciaRecorrer, this.transform.position.y);
                }
                if (right == false)
                {
                    transform.localScale = new Vector2(-1, 1);
                    destination = new Vector2(x - distanciaRecorrer, this.transform.position.y);
                }
                if (movimiento == true) Movimientio(destination);
            }
        }
    }

    void Movimientio(Vector3 des)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(des.x, transform.position.y), vel);
        if (transform.position.x == des.x) right = !right;
    }
}
