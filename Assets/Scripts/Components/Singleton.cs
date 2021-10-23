using System.Linq;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.FindGameObjectsWithTag(tag).Count() > 1)
        {
            Destroy(gameObject);
        }
    }
}
