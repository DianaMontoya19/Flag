using UnityEngine;

namespace Script.Manager
{
    public class ToExit : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        
        public void OnButtonClick()
        {
            _uiManager.ExitGame();
        }
    }
}