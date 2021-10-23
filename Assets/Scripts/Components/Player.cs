using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 1.0f;   

    private Rigidbody2D rb;
    private FootstepPlayer footstepPlayer;

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("LoseScene");
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footstepPlayer = GetComponent<FootstepPlayer>();
    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(h, v).normalized * maxSpeed;
        footstepPlayer.enabled = rb.velocity.magnitude > 0.01f;
    }
}
