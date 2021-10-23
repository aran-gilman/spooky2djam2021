using UnityEngine;
using UnityEngine.Events;

public class Lantern : MonoBehaviour
{
    public float maxDuration = 30.0f;
    public float gameOverValue = 0.05f;
    public float maxSize = 2.0f;

    public float maxVolume = 1.0f;
    public float musicThreshold = 0.5f;

    public UnityEvent onGameOver = new UnityEvent();

    public bool allowGameOver = true;
    
    private float shrinkSpeed;
    private AudioSource audioSource;

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
        else if (newScale < gameOverValue && allowGameOver)
        {
            onGameOver.Invoke();
        }

        if (newScale < 0.0f)
        {
            newScale = 0.0f;
        }
        transform.localScale = new Vector3(newScale, newScale, 1);

        float percent = newScale / maxSize;
        audioSource.enabled = percent < musicThreshold;
        if (audioSource.enabled)
        {
            audioSource.volume = (1 - percent / musicThreshold) * maxVolume;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shrinkSpeed = maxSize / maxDuration;
    }
    
    private void Update()
    {
        UpdateScale(-shrinkSpeed * Time.deltaTime);
    }
}
