using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreListText;
    private string filePath;

    [System.Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int score;
    }

    [System.Serializable]
    public class ScoreList
    {
        public List<ScoreEntry> scores = new List<ScoreEntry>();
    }

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "scores.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ScoreList scoreList = JsonUtility.FromJson<ScoreList>(json);

            scoreListText.text = FormatScores(scoreList.scores);
        }
        else
        {
            scoreListText.text = "No hay puntajes guardados aún.";
        }
    }

    string FormatScores(List<ScoreEntry> scores)
    {
        scores.Sort((a, b) => b.score.CompareTo(a.score)); // Orden descendente
        string result = "";
        for (int i = 0; i < scores.Count; i++)
        {
            result += $"{i + 1}. {scores[i].playerName} - {scores[i].score} pts\n";
        }
        return result;
    }
}