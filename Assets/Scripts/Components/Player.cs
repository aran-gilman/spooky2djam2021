using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 1.0f;

    public Vector2 Forward { get; private set; }

    private Rigidbody2D rb;

    public void WinGame()
    {
        Debug.Log("Victory!");
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(h, v).normalized * maxSpeed;
        if (rb.velocity.magnitude > 0.01f)
        {
            Forward = rb.velocity.normalized;
        }
    }
}
