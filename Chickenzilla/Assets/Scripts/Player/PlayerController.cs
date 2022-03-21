using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 _mouvement;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _mouvement.x = Input.GetAxisRaw("Horizontal");
        _mouvement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _mouvement * moveSpeed * Time.fixedDeltaTime);
    }
}