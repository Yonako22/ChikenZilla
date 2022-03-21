using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 _mouvement;

    public bool isPlayerOne;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayerOne)
        {
            _mouvement.x = Input.GetAxisRaw("Horizontal1");
            _mouvement.y = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            _mouvement.x = Input.GetAxisRaw("Horizontal2");
            _mouvement.y = Input.GetAxisRaw("Vertical2");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _mouvement * moveSpeed * Time.fixedDeltaTime);
    }
}