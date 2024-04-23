using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Manager
{
    public class UIManager : MonoBehaviour
    {
        
        
        [Header("Windows")] //Windows
        [SerializeField] private GameObject _HUDWindow;
        [SerializeField] private GameObject _pauseWindow;
        [SerializeField] private GameObject _gameOverWindow;
        
        [Header("Game Over Counter")] //Game Over Counter
        [SerializeField] private FlagManager _flagManager;
        [SerializeField] private TextMeshProUGUI _pointsBlue;
        [SerializeField] private TextMeshProUGUI _pointsRed;
        private int _uiPointBlue;
        private int _uiPointRed;
        private Timer _timer;

        private void Start()
        {
            // _flagManager = GetComponent<FlagManager>();
            _gameOverWindow.SetActive(false);
            _pauseWindow.SetActive(false);
            _HUDWindow.SetActive(true);
            _timer = FindObjectOfType<Timer>();
        }

        

        public void GameOver()
        {
            _HUDWindow.SetActive(false);
            _gameOverWindow.SetActive(true);
            _pauseWindow.SetActive(false);
        }

        public void Counter()
        {
            var Blue = FlagManager.Instance;
            Blue._teamBlue.text = Blue._pointBlue.ToString("f0");
            // _pointsRed.text = _uiPointRed.ToString();
            // _pointsBlue.text = _uiPointBlue.ToString();
        }
        
        public void ActivatePauseWindow()
        {
            _pauseWindow.SetActive(true);
        }

        public void DeactivatePauseWindow()
        {
            _pauseWindow.SetActive(false);
        }
        
        public void ReturnMainMenu()
        {
            _timer.RestartTimer();
            SceneManager.LoadScene(0);
        }

        public void RestarGame()
        {   
            _timer.RestartTimer();
            SceneManager.LoadScene(1);
 
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        
        }
    
}