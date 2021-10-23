using UnityEngine;

public class Goal : Collectible
{
    private void Start()
    {
        onCollect.AddListener(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().WinGame);
    }
}
