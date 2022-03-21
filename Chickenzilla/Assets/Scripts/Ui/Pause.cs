using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameOver gameOver;
    public bool gamePaused;
    public GameObject pausePanel;
    public Shooting shooting;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused && !gameOver.dead)
            {
                PauseTheGame();
            }
            else
            {
                UnpausedTheGame();
            }
        }
    }

    void PauseTheGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        shooting.canShoot = false;
        gamePaused = true;
    }

    public void UnpausedTheGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        shooting.canShoot = true;
        gamePaused = false;
    }
}
