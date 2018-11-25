using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour {

    public Botones botones;
	void Start () {
        Invoke("Cargar", 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Cargar()
    {
        botones.BackToMenu();
    }
}
