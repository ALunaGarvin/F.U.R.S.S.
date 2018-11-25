using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public Botones final;
    public Animator anim;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Luz")
        {
            Debug.Log(collision.tag);
            anim.SetBool("win", true);
            Invoke("WIN", 1.3f);
        }
    }
    void Start () {
		
	}
	
	void WIN()
    {
        final.YouWin();
    }
}
