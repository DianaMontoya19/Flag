using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Clase que controla la funcionalidad del botón
public class BotthonFuntion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CharacterSelectionManager _charaterSelect; // Referencia al administrador de selección de personajes
    public GameObject targetObject; // Objeto objetivo
    public Animator animator; // Animador del objeto objetivo
    public GameObject PrefabCharacterAsing; // Prefab del personaje asignado

    // Este método se llama al inicio
    private void Start()
    {
        animator = targetObject.GetComponent<Animator>(); // Obtiene el componente Animator del objeto objetivo
        Button button = GetComponent<Button>(); // Obtiene el componente Button del objeto actual
        button.onClick.AddListener(OnButtonClick); // Añade un listener al evento onClick del botón
        _charaterSelect = FindObjectOfType<CharacterSelectionManager>(); // Busca el administrador de selección de personajes en la escena
    }

    // Este método se llama cuando se hace clic en el botón
    public void OnButtonClick()
    {
        _charaterSelect.AsingnateCharacter(PrefabCharacterAsing); // Asigna el personaje seleccionado
        _charaterSelect.StarGame(); // Inicia el juego
    }

    // Este método se llama cuando el puntero entra en el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Cheer", true); // Activa la animación "Cheer"
    }

    // Este método se llama cuando el puntero sale del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Cheer", false); // Desactiva la animación "Cheer"
    }
}
