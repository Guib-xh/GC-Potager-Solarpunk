using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;

    public GameObject pausePanel;
    
    public InputActionReference inputPauseActionReference;
    
    
    public void OnPauseButtonsClicked(InputAction.CallbackContext ctx)
    {
        SwitchPauseStatus();
        pausePanel.SetActive(isPaused);
    }

    private void OnEnable()
    {
        inputPauseActionReference.action.Enable();
        inputPauseActionReference.action.performed += OnPauseButtonsClicked;
        
    }
    
    private void OnDisable()
    {
        inputPauseActionReference.action.Disable();
        inputPauseActionReference.action.performed -= OnPauseButtonsClicked;
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

    public void SwitchPauseStatus()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
