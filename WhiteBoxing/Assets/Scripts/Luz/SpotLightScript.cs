using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightScript : MonoBehaviour {

    public bool SpotLight;
    public Light light;
    public SpriteRenderer render;
    public float intesity, range;
    public Color color;

    private void Start()
    {
        light.intensity = intesity;
        light.range = range;
        light.color = color;
    }
    void Update () {
        if (SpotLight == false)
        {
            light.intensity = 0;
        }
        else light.intensity = intesity;
	}
}
