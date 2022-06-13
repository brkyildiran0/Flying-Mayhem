using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.0f;
    [SerializeField] GameObject explosionEffectObject;
    [SerializeField] MeshRenderer[] shipParts;

    void OnCollisionEnter(Collision other)
    {
        CrashAndRestart();
    }

    void CrashAndRestart()
    {
        explosionEffectObject.GetComponent<ParticleSystem>().Play();    //Play particles
        GetComponentInParent<PlayerMovement>().enabled = false;         //Disable inputs
        ScoreBoard.playerScore = 0;                                     //Reset player score

        DisableMeshRenderers();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void DisableMeshRenderers()
    {
        foreach (MeshRenderer mr in shipParts)
        {
            mr.enabled = false;
        }
    }
}

