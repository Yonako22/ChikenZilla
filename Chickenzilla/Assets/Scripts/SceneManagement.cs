using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
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
}