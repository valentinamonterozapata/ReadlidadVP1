using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;

public class ScoreSaver : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI scoreText;
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
        string savedName = PlayerPrefs.GetString("LastPlayerName", "");
        nameInputField.text = savedName;
    }

    public void SaveScore()
    {
        string playerName = nameInputField.text;
        if (string.IsNullOrEmpty(playerName)) return;

        PlayerPrefs.SetString("LastPlayerName", playerName);
        PlayerPrefs.Save();

        int currentScore = int.Parse(scoreText.text);
        ScoreEntry newEntry = new ScoreEntry { playerName = playerName, score = currentScore };

        ScoreList scoreList = new ScoreList();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            scoreList = JsonUtility.FromJson<ScoreList>(json);
        }

        // Añadir nuevo puntaje
        scoreList.scores.Add(newEntry);

        // Ordenar y limitar a los 5 mejores
        scoreList.scores.Sort((a, b) => b.score.CompareTo(a.score));
        if (scoreList.scores.Count > 5)
        {
            scoreList.scores = scoreList.scores.GetRange(0, 5);
        }

        string updatedJson = JsonUtility.ToJson(scoreList, true);
        File.WriteAllText(filePath, updatedJson);

        Debug.Log($"Guardado: {playerName} - {currentScore} pts");
    }


}
