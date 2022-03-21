using UnityEngine;

public class Projectiles : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerIsHit(true);
            ScoreManager.instance.ComboOff();
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Player2"))
        {
            GameManager.instance.PlayerIsHit(false);
            ScoreManager.instance.ComboOff();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Destroy(gameObject, 3);
    }
}