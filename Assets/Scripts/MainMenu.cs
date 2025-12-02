using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private static PlayerScores playerScores; 

    private static string playerName = "";
    
    public TMP_Text scoreText;
    public TMP_Text nameText;
    public TMP_InputField playerNameInput;

    private static string path;
    
    private void Start()
    {
        path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            ReadScores();
            DisplayScoresOnScoreboard();
        }
        else
        {
            playerScores.scores = new List<PlayerScore>();
        }
        
    }
    
    private void ReadScores()
    {
        string data = File.ReadAllText(Application.persistentDataPath + "/scores.json");
        playerScores = JsonUtility.FromJson<PlayerScores>(data);
    }

    private void DisplayScoresOnScoreboard()
    {
        StringBuilder sbNames = new StringBuilder("");
        StringBuilder sbScores = new StringBuilder("");
        playerScores.scores.Sort((x, y) => y.score - x.score);
        foreach (PlayerScore score in playerScores.scores.Take(5))
        {
            sbNames.AppendLine(score.name);
            sbScores.AppendLine(score.score.ToString());
        }

        scoreText.text = sbScores.ToString();
        nameText.text = sbNames.ToString();
    }

    public void PressPlay()
    {
        playerName = playerNameInput.text;
        SceneManager.LoadScene("main");
    }

    public static void QuitGame(int score)
    {
        PlayerScore currentPlayerScore;
        currentPlayerScore.score = score;
        currentPlayerScore.name = playerName;
        
        playerScores.scores.Add(currentPlayerScore);
        
        string json = JsonUtility.ToJson(playerScores);

        File.WriteAllText(path, json);

    }
}
    
    
    