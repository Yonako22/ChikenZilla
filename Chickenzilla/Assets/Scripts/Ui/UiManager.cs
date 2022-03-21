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
        if (GameManager.instance.playerOneLife == 2)
        {
            heart1.SetActive(false);
        }
        else if (GameManager.instance.playerOneLife == 1)
        {
            heart2.SetActive(false);
        }
        else if (GameManager.instance.playerOneLife <= 0)
        {
            heart3.SetActive(false);
        }
        
        if (GameManager.instance.playerTwoLife == 2)
        {
            heart1P2.SetActive(false);
        }
        else if (GameManager.instance.playerTwoLife == 1)
        {
            heart2P2.SetActive(false);
        }
        else if (GameManager.instance.playerTwoLife <= 0)
        {
            heart3P2.SetActive(false);
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