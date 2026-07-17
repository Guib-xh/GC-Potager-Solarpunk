using System;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public TextMeshProUGUI scoreValue;
    
    public TMP_InputField pseudoInput;
    
    
    void Start()
    {
        scoreValue.text = GameData.LastScore.ToString();
    }
    
    public void OnNextButtonPressed()
    {
        if (String.IsNullOrWhiteSpace(pseudoInput.text)) return;
        LeaderboardStorage.SaveScore(GameData.LastScore, pseudoInput.text);
    }
}
