using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace UI
{
    public class LeaderboardUI : MonoBehaviour
    {
        public GameObject scoreRawPrefab;
        public Transform parent;

        private List<GameObject> _rows = new List<GameObject>();

        void OnEnable()
        {
            List<ScoreEntry> scores = LeaderboardStorage.GetScores();

            foreach (ScoreEntry score in scores)
            {
                GameObject row = Instantiate(scoreRawPrefab, parent);
                row.GetComponent<ScoreRowUI>().pseudoTMP.text = score.pseudo;
                row.GetComponent<ScoreRowUI>().scoreTMP.text = score.score.ToString();
                _rows.Add(row);
            }
        }

        void OnDisable()
        {
            foreach (GameObject row in _rows)
            {
                if (row != null) Destroy(row);
            }

            _rows.Clear();
        }

    }
    
}