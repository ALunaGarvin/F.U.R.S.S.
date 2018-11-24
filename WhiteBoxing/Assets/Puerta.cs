using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour {

    Rigidbody2D rb;
    Collider2D col;
    Animator anim;
    public bool abierto;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void AbrirPuerta()
    {
        anim.SetBool("Abierta", true);
        col.isTrigger = true;
    }
    void CerrarPuerta()
    {
        anim.SetBool("Abierta", false);
        col.isTrigger = false;
    }
}
