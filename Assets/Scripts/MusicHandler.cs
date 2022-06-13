using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    void Awake()
    {
        int amountOfPlayers = FindObjectsOfType<MusicHandler>().Length;
        if (amountOfPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
