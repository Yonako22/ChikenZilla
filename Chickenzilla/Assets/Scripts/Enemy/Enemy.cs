using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.EnemyDeath();
            Destroy(gameObject);
            GameManager.instance.PlayerIsHit();
            ScoreManager.instance.ComboOff();
        }
        else if (other.gameObject.CompareTag("FireBall"))
        {
            GameManager.instance.EnemyDeath();
            Destroy(gameObject);
            ScoreManager.instance.score += 100;
        }
    }
}
