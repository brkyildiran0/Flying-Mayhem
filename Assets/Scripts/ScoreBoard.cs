using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    static public int playerScore = 0;
    TextMeshProUGUI tmp;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();  
    }

    void Update()
    {
        tmp.text = playerScore.ToString();
    }

    public static void increaseScore(int amount)
    {
        playerScore += amount;
    }
}
