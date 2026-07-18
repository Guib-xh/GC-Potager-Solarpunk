using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class StartGameManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
