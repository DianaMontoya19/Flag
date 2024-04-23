using UnityEngine;

namespace Script.Manager
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        private bool _isPaused = false;

        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        private void PauseGame()
        {
            _uiManager.ActivatePauseWindow();
            Time.timeScale = 0f; // Esto pausa el juego
        }

        private void ResumeGame()
        {
            _uiManager.DeactivatePauseWindow();
            Time.timeScale = 1f; // Esto reanuda el juego
        }

        public void ContinueButton()
        {
            TogglePause();
        }
    }
}