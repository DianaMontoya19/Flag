using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamagePlayer : MonoBehaviour
{
    public float radioAtaque = 0.5f; // Radio de ataque del jugador
    private float attack1 = 5; // Daño del ataque 1
    private float attack2 = 10; // Daño del ataque 2
    private float attack3 = 15; // Daño del ataque 3
    private bool haAtacadoMouse0 = false; // Indica si el jugador ha atacado con el botón izquierdo del ratón
    private bool haAtacadoMouse1 = false; // Indica si el jugador ha atacado con el botón derecho del ratón
    private bool haAtacadoE = false; // Indica si el jugador ha atacado con la tecla E
    private Transform actualTransform; // Referencia al componente Transform del jugador
    public LayerMask layerMask; // Máscara de capa para determinar qué objetos pueden ser atacados
    private CharacterIA characterIA; // Referencia al componente CharacterIA del enemigo

    void Awake()
    {
        actualTransform = transform; // Asigna el componente Transform a la variable actualTransform
    }

    private void Start()
    {
        characterIA = FindObjectOfType<CharacterIA>(); // Busca en la escena el objeto con el componente CharacterIA y lo asigna a la variable characterIA
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja una esfera en la posición del jugador con el radio de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }

    void Update()
    {
        // Si el jugador suelta el botón izquierdo del ratón y no ha atacado aún, realiza el ataque 1
        if (Input.GetMouseButtonUp(0) && !haAtacadoMouse0)
        {
            Atacar(attack1);
            haAtacadoMouse0 = true;
        }
        // Si el jugador suelta el botón derecho del ratón y no ha atacado aún, realiza el ataque 2
        if (Input.GetMouseButtonUp(1) && !haAtacadoMouse1)
        {
            Atacar(attack2);
            haAtacadoMouse1 = true;
        }
        // Si el jugador suelta la tecla E y no ha atacado aún, realiza el ataque 3
        if (Input.GetKeyUp(KeyCode.E) && !haAtacadoE)
        {
            Atacar(attack3);
            haAtacadoE = true;
        }

        // Si el jugador suelta cualquiera de los botones de ataque, resetea las variables de control de ataque
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.E))
        {
            haAtacadoMouse0 = false;
            haAtacadoMouse1 = false;
            haAtacadoE = false;
        }
    }

    void Atacar(float attack)
    {
        // Obtiene todos los colliders dentro del radio de ataque que corresponden a la máscara de capa
        Collider[] colliders = Physics.OverlapSphere(GetProbePosition(), radioAtaque, layerMask);

        foreach (Collider collider in colliders)
        {
            // Si el collider pertenece al equipo B, le inflige daño
            if (collider.CompareTag("TeamB"))
            {
                characterIA.IGetDamage(attack);
            }
        }
    }

    Vector3 GetProbePosition()
    {
        // Devuelve la posición del jugador ajustada en el eje Y
        return actualTransform.position + actualTransform.TransformVector(new Vector3(0.0f, 1.2f, 0f));
    }
}
