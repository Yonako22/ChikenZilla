using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart1P2;
    public GameObject heart2P2;
    public GameObject heart3P2;
    public GameObject player;
    public GameObject screenBorder_Left;
    public GameObject screenBorder_Right;
    
    float startPos;
    float endPos;
    float playerPos;

    float playerAvancement;
    public Slider barProgression;

    private void Start()
    {
        startPos = screenBorder_Left.transform.position.x;
        endPos = screenBorder_Right.transform.position.x;
    }

    void Update()
    {
        if (GameManager.instance.playerOneLife == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (GameManager.instance.playerOneLife == 2)
        {
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (GameManager.instance.playerOneLife == 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(true);
        }
        else if (GameManager.instance.playerOneLife <= 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }

        if (!GameManager.instance.soloPlayerMode)
        {
            if (GameManager.instance.playerTwoLife == 3)
            {
                heart1P2.SetActive(true);
                heart2P2.SetActive(true);
                heart3P2.SetActive(true);
            }
            else if (GameManager.instance.playerTwoLife == 2)
            {
                heart1P2.SetActive(false);
                heart2P2.SetActive(true);
                heart3P2.SetActive(true);
            }
            else if (GameManager.instance.playerTwoLife == 1)
            {
                heart1P2.SetActive(false);
                heart2P2.SetActive(false);
                heart3P2.SetActive(true);

            }
            else if (GameManager.instance.playerTwoLife <= 0)
            {
                heart1P2.SetActive(false);
                heart2P2.SetActive(false);
                heart3P2.SetActive(false);
            } 
        }
        AvancementBarProgression();
    }

    void AvancementBarProgression()
    {
        playerPos = player.transform.position.x;
        playerAvancement = (playerPos - startPos) / endPos;
        barProgression.value = playerAvancement;
    }

   
}