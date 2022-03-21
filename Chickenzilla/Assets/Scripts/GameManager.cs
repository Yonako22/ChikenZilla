using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  
  public int life;
  public Animation anim;
  public Pause pause;
  public AudioSource audioSource;
  public AudioClip enemyDeathSound;
  public float timeOfInvicibility;
  private float cooldown;
  
  private void Awake()
  {
      if (instance != null)
      {
        Debug.LogError("PLus d'une instance de GameManager dans la scene");
        return;
      }
      
      instance = this;
  }

  private void Start()
  {
      life = 3;
      pause.UnpausedTheGame();
      cooldown = timeOfInvicibility;
  }

  private void Update()
  {
      if (cooldown > 0f)
      {
          cooldown -= Time.deltaTime;
      }
  }

  public void PlayerIsHit()
  {
      if (cooldown <= 0f)
      {
        life--;
        anim.Play("DegatsPlayer");
        cooldown = timeOfInvicibility;
      }
  }

  public void EnemyDeath()
  {
      audioSource.PlayOneShot(enemyDeathSound);
  }
}
