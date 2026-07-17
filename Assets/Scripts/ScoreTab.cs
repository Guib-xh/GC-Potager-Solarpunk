using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTab : MonoBehaviour
{
    public GameObject scoreRawPrefab;
    public Transform parent;
    void OnEnable()
    {
        List<ScoreEntry> scores = HighScoreManager.GetScores();

        foreach (ScoreEntry score in scores)
        {
            Debug.Log(score);
            GameObject row = Instantiate(scoreRawPrefab, parent);
            row.GetComponentInChildren<TextMeshProUGUI>().text = $"{score.pseudo} ______ {score.score.ToString()}";
        }
    }
    
}
