using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public int time;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "SpotLight")
        {
            if (collision.GetComponent<SpotLightScript>().intesity <= 1)
            {
                collision.gameObject.GetComponent<SpotLightScript>().SpotLight = true;
                Destroy(this.gameObject);
            }
        }
        if (collision.tag == "Chica")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("win", true);
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
