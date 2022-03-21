using UnityEngine;

public class MilkBall : MonoBehaviour
{
    private Transform player;
    private Vector3 playerTrajectory;
    public float milkBallSpeed = 8f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        playerTrajectory = Vector2.MoveTowards(transform.position, player.position, milkBallSpeed * Time.deltaTime);
        transform.position = playerTrajectory;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerIsHit();
        }
        Destroy(gameObject);
    }
}