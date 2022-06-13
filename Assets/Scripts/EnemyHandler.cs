using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        gameObject.SetActive(false);
    }
}
