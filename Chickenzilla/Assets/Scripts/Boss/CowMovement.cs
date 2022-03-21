using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public float speed;
    public float y;
    public Rigidbody2D rb;
    public Boss boss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (boss.bossLife <= 0)
        {
            rb.gravityScale = 0.1f;
        }
        else
        {
            y = Mathf.PingPong(Time.time * speed, 1.5f) -0.7f;
            rb.transform.position = new Vector3(rb.transform.position.x, y);
        }
    }
}