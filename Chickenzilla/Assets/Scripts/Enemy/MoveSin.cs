using UnityEngine;

public class MoveSin : MonoBehaviour
{
    private float sinCenterY;
    public float amplitude;
    
    void Start()
    {
        sinCenterY = transform.position.y;
    }
    
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x) * amplitude;
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }
}