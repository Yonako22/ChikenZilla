using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  
  public int playerOneLife;
  public int playerTwoLife;

  public Animation anim;
  public Pause pause;
  public AudioSource audioSource;
  public AudioClip enemyDeathSound;
  public float timeOfInvicibility;
  private float cooldown;

  public bool soloPlayerMode;
  public GameObject player2;
  
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
      playerOneLife = 3;
      playerTwoLife = 3;
      pause.UnpausedTheGame();
      cooldown = timeOfInvicibility;

      if (soloPlayerMode)
      {
          player2.SetActive(false);
      }
  }

  private void Update()
  {
      if (cooldown > 0f)
      {
          cooldown -= Time.deltaTime;
      }
  }

  public void PlayerIsHit(bool playerOneIsHit)
  {
      if (playerOneIsHit)
      {
          if (cooldown <= 0f)
          {
              playerOneLife--;
              anim.Play("DegatsPlayer");
              cooldown = timeOfInvicibility;
          }
      }
      else
      {
          if (cooldown <= 0f)
          {
              playerTwoLife--;
              anim.Play("DegatsPlayer");
              cooldown = timeOfInvicibility;
          }
      }
     
  }

  public void PlayerLifeUp()
  {
      // if (life<3)
      // {
      //     life++;
      // }
  }

  public void EnemyDeath()
  {
      audioSource.PlayOneShot(enemyDeathSound);
  }
}
