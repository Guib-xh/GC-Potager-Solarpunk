using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class TimeManager : MonoBehaviour
    {
        public float gameTime = 120f;
        private bool _isEndGame = false;

        public TextMeshProUGUI timerValueGO;

        public ScoreManager scoreManager;

        // Update is called once per frame
        void Update()
        {
            timerValueGO.text = FormatTimerToText();
            if (_isEndGame) return;
            if (gameTime <= 0f)
            {
                Debug.Log("Game Over");
                scoreManager.SaveSessionScore();
                SceneManager.LoadScene(2);
                _isEndGame = true;
            }
            else
            {
                gameTime -= Time.deltaTime;
            }

        }

        private string FormatTimerToText()
        {
            int minutes = (int)gameTime / 60;
            int seconds = (int)gameTime % 60;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}