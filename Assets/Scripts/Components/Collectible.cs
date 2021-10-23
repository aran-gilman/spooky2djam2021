using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    public AudioClip collectionSound;
    public UnityEvent onCollect = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collectionSound != null)
        {
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.PlayOneShot(collectionSound);
            }
        }
        onCollect.Invoke();
        Destroy(gameObject);
    }
}
