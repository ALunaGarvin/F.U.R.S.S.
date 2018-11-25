using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightScript : MonoBehaviour {

    public bool SpotLight;
    public Light light;
    Animator anim;
    public float intesity, range;
    public Color color;

    private void Start()
    {
        anim = GetComponent<Animator>();
        light.intensity = intesity;
        light.range = range;
        light.color = color;
    }
    void Update()
    {
        if (SpotLight == false)
        {
            anim.SetBool("Fuego", false);
            light.intensity = 0;
        }
        else
        {
            anim.SetBool("Fuego", true);
            light.intensity = intesity;
        }
    }
}
