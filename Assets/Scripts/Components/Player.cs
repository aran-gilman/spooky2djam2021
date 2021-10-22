using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 1.0f;

    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(h, v).normalized * maxSpeed;
    }
}
