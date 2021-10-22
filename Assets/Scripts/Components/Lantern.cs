using UnityEngine;

public class Lantern : MonoBehaviour
{
    public float maxDuration = 30.0f;
    public float gameOverValue = 0.05f;

    private float startSize;
    private float shrinkSpeed;

    private void Start()
    {
        startSize = transform.localScale.x;
        shrinkSpeed = startSize / maxDuration;
    }
    
    private void Update()
    {
        float newScale = transform.localScale.x - Time.deltaTime * shrinkSpeed;
        transform.localScale = new Vector3(newScale, newScale, 1);
    }
}
