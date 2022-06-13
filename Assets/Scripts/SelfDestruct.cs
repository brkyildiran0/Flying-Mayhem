using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float delayBeforeDestruct = 1.0f;

    void Start()
    {
        Destroy(gameObject, delayBeforeDestruct);
    }
}
