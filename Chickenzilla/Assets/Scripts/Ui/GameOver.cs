using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deathPanel;
    public bool dead;
    public AudioSource audioSource;
    public AudioClip sound;
    void Update()
    {
        if (GameManager.instance.playerOneLife == 0 || GameManager.instance.playerTwoLife == 0 )
        {
            Time.timeScale = 0;          
            audioSource.PlayOneShot(sound);
            deathPanel.SetActive(true);
            dead = true;
        }
        else
        {
            dead = false;
        }

        if (dead && Input.GetKeyDown(KeyCode.Return))
        {
            deathPanel.SetActive(false);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
            Time.timeScale = 1;
        }
    }
}
