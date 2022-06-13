using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject mainParent;
    [SerializeField] int scoreByDestroying = 1;

    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = mainParent.transform;
        gameObject.SetActive(false);

        ScoreBoard.increaseScore(scoreByDestroying);
    }
}