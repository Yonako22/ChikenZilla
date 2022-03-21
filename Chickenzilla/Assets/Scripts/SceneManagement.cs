using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class SceneManagement : MonoBehaviour
{
    public GameObject ui;

    public int sceneToLoad;
    public Sprite slashartP1;
    public Sprite slashartP2;

    private void Start()
    {
        sceneToLoad = 1;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(00);
    }
    
    public void ExitGame() 
    {  
        Application.Quit();  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }
    
    public void Click1Player()
    {
        sceneToLoad = 1;
        ui.GetComponent<Image>().sprite = slashartP1;
    }
    
    public void Click2Player()
    {
        sceneToLoad = 2;
        ui.GetComponent<Image>().sprite = slashartP2;
    }
}