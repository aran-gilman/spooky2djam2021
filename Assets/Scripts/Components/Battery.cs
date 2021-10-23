using UnityEngine;

public class Battery : Collectible
{
    public float refreshAmount = 0.5f;

    private void Start()
    {
        onCollect.AddListener(
            delegate
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Lantern>().Refresh(refreshAmount);
            });
    }
}
