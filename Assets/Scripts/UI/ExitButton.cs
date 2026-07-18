using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ExitButton : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}