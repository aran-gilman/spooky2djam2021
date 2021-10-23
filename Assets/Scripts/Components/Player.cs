using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public GameObject cutscenePlayer;

    private Rigidbody2D rb;
    private FootstepPlayer footstepPlayer;
    private Animator animator;

    public void WinGame()
    {
        cutscenePlayer.GetComponent<WinCutscene>().enabled = true;
    }

    public void GameOver()
    {
        cutscenePlayer.GetComponent<LoseCutscene>().enabled = true;
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footstepPlayer = GetComponent<FootstepPlayer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(h, v).normalized * maxSpeed;
        footstepPlayer.enabled = rb.velocity.magnitude > 0.01f;
        animator.enabled = footstepPlayer.enabled;
        animator.SetFloat("xVelocity", h);
        animator.SetFloat("yVelocity", v);
    }
}
