using System;
using UnityEngine;
using Unity.UI;

namespace Script.Manager
{
   
    public class ToSelectCharacter : MonoBehaviour
    {
        
        [SerializeField] private UIManager _uiManager;
        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        
        public void OnButtonClick()
        {
            _uiManager.RestarGame();
        }
        
        
        
    }
}