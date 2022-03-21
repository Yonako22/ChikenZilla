using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }
}