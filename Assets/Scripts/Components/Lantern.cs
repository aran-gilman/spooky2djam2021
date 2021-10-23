using UnityEngine;
using UnityEngine.Events;

public class Lantern : MonoBehaviour
{
    public float maxDuration = 30.0f;
    public float gameOverValue = 0.05f;
    public float maxSize = 2.0f;

    public UnityEvent onGameOver = new UnityEvent();
    
    private float shrinkSpeed;

    public void Refresh(float percent)
    {
        UpdateScale(maxSize * percent);
    }

    private void UpdateScale(float changeAmount)
    {
        float newScale = transform.localScale.x + changeAmount;
        if (newScale > maxSize)
        {
            newScale = maxSize;
        }
        else if (newScale < gameOverValue)
        {
            onGameOver.Invoke();
        }
        transform.localScale = new Vector3(newScale, newScale, 1);
    }

    private void Start()
    {
        shrinkSpeed = maxSize / maxDuration;
    }
    
    private void Update()
    {
        UpdateScale(-shrinkSpeed * Time.deltaTime);
    }
}
