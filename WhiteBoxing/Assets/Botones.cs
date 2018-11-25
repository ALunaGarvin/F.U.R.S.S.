using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {

    public bool NivelDisponible;
    public Niveles niveles;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LevelSelection()
    {
        niveles.menu.gameObject.SetActive(false);
        niveles.levelSelection.gameObject.SetActive(true);
    }
    public void Menu()
    {
        niveles.menu.gameObject.SetActive(true);
        niveles.levelSelection.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadLevel(int num)
    {

            niveles.LevelSelected = num;
            Debug.Log(num);
            niveles.SpriteLevel = niveles.niveles[num].mapa;
            SceneManager.LoadScene("SampleScene");
            niveles.LevelSelected = num;
            niveles.SpriteLevel = niveles.niveles[num].mapa;
    }
    public void YouLose()
    {
        SceneManager.LoadScene("YouLose");
    }
    public void YouWin()
    {
        SceneManager.LoadScene("YouWin");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
