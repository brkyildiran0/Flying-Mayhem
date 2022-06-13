using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject mainParent;
    [SerializeField] int health;
    [SerializeField] int scoreByHitting;

    void Awake()
    {
        health = Random.Range(1, 6);
        scoreByHitting = 1;
    }

    void OnParticleCollision(GameObject other)
    {
        health--;
        if (health == 0)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = mainParent.transform;
            gameObject.SetActive(false);

            ScoreBoard.increaseScore(scoreByHitting);
        }
        else
        {
            ScoreBoard.increaseScore(scoreByHitting);
        }   
    }
}