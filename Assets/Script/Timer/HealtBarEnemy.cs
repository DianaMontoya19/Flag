using UnityEngine;
using UnityEngine.UI;

public class HealtBarEnemy : MonoBehaviour
{
    public Slider HealtBar; // Referencia al componente Slider que representa la barra de salud del enemigo
    private Timer timer; // Referencia al componente Timer que controla el tiempo del juego
    private float maxHealth = 100; // La salud máxima que puede tener el enemigo

    void Start()
    {
        timer = FindObjectOfType<Timer>(); // Busca en la escena el objeto con el componente Timer y lo asigna a la variable timer
    }

    void Update()
    {
        // Mapea la salud del enemigo (de 0 a maxHealth) a un valor entre 0 y 1
        float mappedHealth = Mathf.Clamp01(timer.EnemyHealth / maxHealth);
        // Asigna el valor mapeado a la barra de salud
        HealtBar.value = mappedHealth;


        // Imprime el valor mapeado en la consola
        //print(mappedHealth);

    }
}
