using UnityEngine;

public class LifeUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Quand la fireball rencontre le bord de l'écran
        {
            GameManager.instance.PlayerLifeUp(true);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player2")) // Quand la fireball rencontre le bord de l'écran
        {
            GameManager.instance.PlayerLifeUp(false);
            Destroy(gameObject);
        }
    }
}