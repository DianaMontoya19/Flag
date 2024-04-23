using UnityEngine;

namespace Script.Manager
{
    public class ToMenu : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        
        public void OnButtonClick()
        {
            _uiManager.ReturnMainMenu();
        }
    }
}