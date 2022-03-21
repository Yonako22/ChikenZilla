using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deathPanel;
    public bool dead;
    public AudioSource audioSource;
    public AudioClip sound;

    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    void Update()
    {
        if (GameManager.instance.playerOneLife == 0 && GameManager.instance.playerTwoLife == 0 )
        {
            Time.timeScale = 0;          
            audioSource.PlayOneShot(sound);
            deathPanel.SetActive(true);
            dead = true;
        }

        if (GameManager.instance.playerOneLife == 0)
        {
            playerOne.SetActive(false);
        }
        if (GameManager.instance.playerTwoLife == 0)
        {
            playerTwo.SetActive(false);
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
