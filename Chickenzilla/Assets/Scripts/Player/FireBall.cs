using UnityEngine;

public class FireBall : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fireBallSound;
    public GameObject lifeUp;


    private void Awake()
    {
        audioSource.PlayOneShot(fireBallSound);
        gameObject.GetComponent<Animator>().SetBool("shot", true);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ScreenBorder")) // Quand la fireball rencontre le bord de l'écran
        {
            Destroy(gameObject);
        }
        
        if (col.gameObject.CompareTag("Enemy"))
        { 
            ScoreManager.instance.Counter1();
            EnemyDying();
        }
        else if (col.gameObject.CompareTag("Enemy2"))
        {
            ScoreManager.instance.Counter2();
            EnemyDying();
        }
        else if (col.gameObject.CompareTag("Enemy3"))
        {
            ScoreManager.instance.Counter3();
            EnemyDying();
        }
        else if (col.gameObject.CompareTag("EnemyProjectile"))
        {
            Instantiate(lifeUp, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }

    void EnemyDying()
    {
        Destroy(gameObject);
    }
    
    private void OnEnable() // au cas où la fireball rencontre rien
    {
        Destroy(gameObject, 1);
    }
}