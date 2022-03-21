using UnityEngine;

public class MeteorCow : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public float travelSpeed;
    private BoxCollider2D col;
    private Vector2 vectorPlayerCow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindWithTag("Player");
        target = player.transform;
        col = GetComponent<BoxCollider2D>();
        vectorPlayerCow = target.position - transform.position;
        rb.AddForce(vectorPlayerCow * travelSpeed);
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(col);
            GameManager.instance.PlayerIsHit(true);
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            Destroy(col);
            GameManager.instance.PlayerIsHit(false);
        }
    }
}