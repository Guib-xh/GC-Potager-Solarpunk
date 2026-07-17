using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int _score = 0;
    
    public TextMeshProUGUI scoreValueGO;

    public void AddPointToScore(int points)
    {
        _score += points;
        scoreValueGO.text = _score.ToString();
    }

    public void SaveSessionScore()
    {
        DataGame.LastScore = _score;
    }
}
