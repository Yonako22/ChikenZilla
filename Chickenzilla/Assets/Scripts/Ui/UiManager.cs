using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
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
        if (GameManager.instance.life == 2)
        {
            heart1.SetActive(false);
        }
        else if (GameManager.instance.life == 1)
        {
            heart2.SetActive(false);
        }
        else if (GameManager.instance.life <= 0)
        {
            heart3.SetActive(false);
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