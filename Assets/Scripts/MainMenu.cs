using System;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    private PlayerScore[] scores;

    private TMP_Text scoreText;
    
    private void Start()
    {
        ReadScores();
        DisplayScoresOnScoreboard();
    }

    private void ReadScores()
    {
        string data = File.ReadAllText(Application.persistentDataPath + "/scores.json");
        scores = JsonUtility.FromJson<PlayerScore[]>(data);
    }

    private void DisplayScoresOnScoreboard()
    {
        StringBuilder sb = new StringBuilder("");
        foreach (PlayerScore playerScore in scores)
        {
            sb.AppendLine($"Name: {playerScore.name} | Score: {playerScore.score}");
        }

        scoreText.text = sb.ToString(); 
    }
}
    
    
    