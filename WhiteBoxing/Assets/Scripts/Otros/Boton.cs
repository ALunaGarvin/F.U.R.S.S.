using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {

    public bool activado;
    public SpriteRenderer render;
    public Sprite activo, desactivado;
    public Puerta[] puertas;
    public Puerta closestPuerta = null;
	void Start ()
    {
        float distanceToClosestPuerta = Mathf.Infinity;
        transform.parent = null;
        puertas = GameObject.FindObjectsOfType<Puerta>();

        foreach (Puerta currentPuerta in puertas)
        {
            float distanceToPuerta = (currentPuerta.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPuerta < distanceToClosestPuerta)
            {
                distanceToClosestPuerta = distanceToPuerta;
                closestPuerta = currentPuerta;
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == 10)
        {
            activado = false;
            closestPuerta.abierto = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == 10)
        {
            activado = true;
            closestPuerta.abierto = false;
        }
    }
    // Update is called once per frame
    void Update () {
        if (activado == true)
        {
            render.sprite = activo;
        }
        else render.sprite = desactivado;
	}
}
