using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rana : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    Collider2D col;
    public SpriteRenderer spr;
    public float vel, distanciaMinSalto, fuerzaSalto;
    private bool llega = false, OnFloor = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            OnFloor = true;
            anim.SetBool("Salto", false);
            anim.SetBool("Caminar", false);
        }
        if (collision.gameObject.layer == 10)
        {
            Physics2D.IgnoreCollision(collision.collider, col);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Luz")
        {
            anim.SetBool("Caminar", true);
            Vector2 movDirc = new Vector2(col.transform.position.x - transform.position.x, 0);
            transform.Translate(movDirc.normalized * vel * Time.deltaTime);
            if (movDirc.normalized.x < 0)
            {
                spr.flipX = true;
            }
            else spr.flipX = false;
            Invoke("PararAnim", 1);

            if (OnFloor == true)
            {
                if (col.transform.position.y - transform.position.y >= distanciaMinSalto)
                {
                    OnFloor = false;
                    anim.SetBool("Salto", true);
                    rb.AddForce(Vector2.up * fuerzaSalto * 200 * Time.deltaTime);
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Luz")
        {
            rb.velocity = rb.velocity.normalized;
        }
    }
    void PararAnim()
    {
        anim.SetBool("Caminar", false);
    }
}
