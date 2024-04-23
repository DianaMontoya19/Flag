using System.Collections.Generic;
using UnityEngine;

public class FuncionMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private GameObject optionsWindow;
    [SerializeField] private GameObject creditsWindow;
    [SerializeField] private GameObject characterWindow;
    [SerializeField] private GameObject initialMenu; // Nuevo GameObject para el InitialMenu

    // Lista de todos los menús
    private List<GameObject> allMenus;

    private void Start()
    {
        // Inicializa la lista de menús y agrega todos los menús a la lista
        allMenus = new List<GameObject> {tutorialWindow ,optionsWindow, creditsWindow, characterWindow, initialMenu };

        // Desactiva todos los menús al inicio
        foreach (var menu in allMenus)
        {
            menu.SetActive(false);
        }

        // Activa el InitialMenu al inicio
        initialMenu.SetActive(true);
    }

    // Método para activar un menú específico y desactivar todos los demás
    private void ActivateMenu(GameObject menuToActivate)
    {
        foreach (var menu in allMenus)
        {
            menu.SetActive(false);
        }

        menuToActivate.SetActive(true);
    }

    public void Options()
    {
        ActivateMenu(optionsWindow);
    }

    public void Tutorial()
    {
        ActivateMenu(tutorialWindow);
    }

    public void Credits()
    {
        ActivateMenu(creditsWindow);
    }

    public void SelectCharacter()
    {
        ActivateMenu(characterWindow);
    }

    // Nuevo método para volver al InitialMenu
    public void ReturnToInitialMenu()
    {
        ActivateMenu(initialMenu);
    }

    // Nuevo método para salir del juego
    public void ExitGame()
    {
        Application.Quit();
    }
}