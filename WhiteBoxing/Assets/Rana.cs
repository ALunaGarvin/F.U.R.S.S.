using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Rana : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    public float vel, distanciaMinSlato, distanciaMaxSalto, fuerzaSalto;
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
                anim.SetBool("Salto", false);
                OnFloor = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Luz")
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(col.transform.position.x, transform.position.y), vel);
            if((col.transform.position.y - this.transform.position.y >= distanciaMinSlato)  && OnFloor == true)
            {
                rb.AddForce(Vector2.up * fuerzaSalto * 200 * Time.deltaTime);
                anim.SetBool("Salto", true);
                alturaSalto = transform.position.y;
                OnFloor = false;
            }
            
        }

    }

    private void Update()
    {
        if(this.transform.position.x == Xposition)
        {
            llega = true;
        }
        if(llega == true && OnFloor == true)
        {
            if (transform.position.x != Xposition) transform.position = new Vector2(Xposition, this.transform.position.y);
        }
        if(OnFloor == false && (transform.position.y - alturaSalto >= distanciaMaxSalto))
        {
            rb.velocity = rb.velocity.normalized * 0;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Luz")
        {
            rb.velocity = rb.velocity.normalized;
        }
    }

}
