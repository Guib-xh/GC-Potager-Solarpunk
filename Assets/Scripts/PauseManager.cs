using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;
    
    public void OnPauseButtonsClicked()
    {
        SwitchPauseStatus();
    }
    
    public void ReloadGame()
    {
        SwitchPauseStatus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ExitGame()
    {
        SwitchPauseStatus();
        SceneManager.LoadScene(0);
    }

    private void SwitchPauseStatus()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
