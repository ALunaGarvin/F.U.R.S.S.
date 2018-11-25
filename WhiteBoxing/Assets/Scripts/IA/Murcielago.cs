using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    public float vel;
    float Xposition;
    public SpriteRenderer spr;
    private float alturaSalto;
    private bool llega = false, OnFloor = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detecta si está en el suelo o no
        if (OnFloor == false)
        {
            if (collision.gameObject.layer == 8)
            {
                OnFloor = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Luz")
        {
            Vector2 movDirc = transform.position - col.transform.position;
            transform.Translate(movDirc.normalized * vel * Time.deltaTime);
            if (movDirc.normalized.x < 0)
            {
                spr.flipX = true;
            }


        }

    }

    private void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Luz")
        {
            rb.velocity = rb.velocity.normalized;
        }
    }
}
