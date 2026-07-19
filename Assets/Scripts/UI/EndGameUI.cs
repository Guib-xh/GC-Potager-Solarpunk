using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EndGameUI : MonoBehaviour
    {

        public TextMeshProUGUI scoreValueTMP;

        public TMP_InputField pseudoInput;


        void Start()
        {
            Debug.Log("scoreValueTMP: " + scoreValueTMP.text);
            Debug.Log("GameData.LastScore.ToString(): " + GameData.LastScore);
            scoreValueTMP.text = GameData.LastScore.ToString();
        }

        public void OnNextButtonPressed()
        {
            if (String.IsNullOrWhiteSpace(pseudoInput.text)) return;
            Managers.LeaderboardStorage.SaveScore(GameData.LastScore, pseudoInput.text);
        }
    }
}