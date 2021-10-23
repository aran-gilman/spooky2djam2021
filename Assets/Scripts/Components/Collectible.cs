using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    public UnityEvent onCollect = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        onCollect.Invoke();
        Destroy(gameObject);
    }
}
