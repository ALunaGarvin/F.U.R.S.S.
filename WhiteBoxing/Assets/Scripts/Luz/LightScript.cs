using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public int time;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "SpotLight")
        {
            collision.gameObject.GetComponent<SpotLightScript>().SpotLight = true;
            collision.gameObject.GetComponent<SpotLightScript>().render.enabled = true;
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
