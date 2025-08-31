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

        PlayerPrefs.SetString("LastPlayerName", playerName); // 👈 Guarda el nombre
        PlayerPrefs.Save(); // 👈 Opcional: fuerza el guardado inmediato

        int currentScore = int.Parse(scoreText.text);

        ScoreEntry newEntry = new ScoreEntry { playerName = playerName, score = currentScore };

        ScoreList scoreList = new ScoreList();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            scoreList = JsonUtility.FromJson<ScoreList>(json);
        }

        scoreList.scores.Add(newEntry);
        string updatedJson = JsonUtility.ToJson(scoreList, true);
        File.WriteAllText(filePath, updatedJson);

        Debug.Log($"Guardado: {playerName} - {currentScore} pts");
    }

}
