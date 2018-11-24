using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    public float vel;
    float Xposition;
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
             rb.AddForce((transform.position - col.transform.position) * vel * 200 * Time.deltaTime);


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
