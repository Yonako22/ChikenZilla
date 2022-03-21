using UnityEngine;

public class LifeUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Quand la fireball rencontre le bord de l'écran
        {
            GameManager.instance.PlayerLifeUp(true);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player2")) // Quand la fireball rencontre le bord de l'écran
        {
            GameManager.instance.PlayerLifeUp(false);
            Destroy(gameObject);
        }
    }
}
