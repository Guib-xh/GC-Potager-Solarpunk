using LitMotion;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        public bool isPaused;

        public GameObject pausePanel;
        public RectTransform pausePanelTransform;
        
        public InputActionReference inputPauseActionReference;

        public float motionDuration = 0.4f;
        private MotionHandle _fadeHandle;
        private MotionHandle _scaleHandle;
        
        
        public void OnPauseButtonsClicked(InputAction.CallbackContext ctx)
        {
            if (!isPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
           
        }

        public void OpenPauseMenu()
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            
            if (_fadeHandle.IsActive()) _fadeHandle.Cancel();

            float fadeStart = 0f;
            float fadeEnd = 1f;
            _fadeHandle = LMotion.Create(fadeStart, fadeEnd, motionDuration)
                .WithEase(Ease.OutQuad)
                .WithScheduler(MotionScheduler.UpdateIgnoreTimeScale)
                .Bind(x => pausePanel.GetComponent<CanvasGroup>().alpha = x);
            
            if (_scaleHandle.IsActive()) _scaleHandle.Cancel();
            
            float scaleStart = 0.5f;
            float scaleEnd = 1f;
            _scaleHandle = LMotion.Create(scaleStart, scaleEnd, motionDuration)
                .WithEase(Ease.OutBack)
                .WithScheduler(MotionScheduler.UpdateIgnoreTimeScale)
                .Bind(x => pausePanelTransform.localScale = Vector3.one * x);
        }
        
        public void ClosePauseMenu()
        {
            isPaused = false;
            

            
            if (_fadeHandle.IsActive()) _fadeHandle.Cancel();

            float fadeStart = 1f;
            float fadeEnd = 0f;
            _fadeHandle = LMotion.Create(fadeStart, fadeEnd, motionDuration)
                .WithEase(Ease.OutQuad)
                .WithScheduler(MotionScheduler.UpdateIgnoreTimeScale)
                .WithOnComplete(() => pausePanel.SetActive(false))
                .Bind(x => pausePanel.GetComponent<CanvasGroup>().alpha = x);


            if (_scaleHandle.IsActive()) _scaleHandle.Cancel();
            
            float scaleStart = 1f;
            float scaleEnd = 0.5f;
            _scaleHandle = LMotion.Create(scaleStart, scaleEnd, motionDuration)
                .WithEase(Ease.OutBack)
                .WithScheduler(MotionScheduler.UpdateIgnoreTimeScale)
                .WithOnComplete(() => pausePanel.SetActive(false))
                .Bind(x => pausePanelTransform.localScale = Vector3.one * x);
            
            Time.timeScale = 1f;
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
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void ExitGame()
        {
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}

