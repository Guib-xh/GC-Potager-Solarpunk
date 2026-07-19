using LitMotion;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        int _score;
        float _displayedScore;
        public float countDuration = 1f;
        public TextMeshProUGUI scoreValueTMP;
        
        MotionHandle _scoreHandle;

        public void AddPointToScore(int points)
        {
            _score += points;
            if (_scoreHandle.IsActive()) _scoreHandle.Cancel();

            _scoreHandle = LMotion.Create(_displayedScore, _score, countDuration)
                .WithEase(Ease.OutQuad)
                .WithOnComplete(PunchScoreText)
                .Bind(x =>
                {
                    _displayedScore = x;
                    scoreValueTMP.text = Mathf.RoundToInt(x).ToString();
                });
        }

        void PunchScoreText()
        {
            LMotion.Punch.Create(Vector3.one, Vector3.one * 0.15f, 0.25f)
                .WithFrequency(8)
                .Bind(x => scoreValueTMP.transform.localScale = x);
        }

        public void SaveSessionScore()
        {
            GameData.LastScore = _score;
        }
    }
}
