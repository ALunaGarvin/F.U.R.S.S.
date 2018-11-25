using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour {

    public LevelManagement[] niveles;
    public Texture2D SpriteLevel;
    public int LevelSelected;
    public Botones botones;
    public GameObject menu, levelSelection;
    private void Start()
    {

        DontDestroyOnLoad(this.gameObject);
        levelSelection.SetActive(false);
    }

}
