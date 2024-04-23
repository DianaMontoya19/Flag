using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIA : MonoBehaviour
{

    public float radioAtaque = 0.5f;
    private float attack1 = 5;
    private float attack2 = 10;
    private float attack3 = 15;
    private Transform actualTransform;
    public LayerMask layerMask;
    private Character character;
    private CharacterIA characterIA; // Referencia al componente CharacterIA de la IA
    void Awake()
    {
        actualTransform = transform;
        character = FindObjectOfType<Character>();
        characterIA = FindObjectOfType<CharacterIA>();

    }
        void OnDrawGizmosSelected()
    {
        // Dibuja una esfera en la posición de la IA con el radio de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }
    void Update()
    {
        // Este método está vacío, pero se puede usar para actualizar la lógica de la IA en cada frame
    }

    public void Atacar(float attack)

    {
        // Obtiene todos los colliders dentro del radio de ataque que corresponden a la máscara de capa
        Collider[] colliders = Physics.OverlapSphere(GetProbePosition(), radioAtaque, layerMask);

        foreach (Collider collider in colliders)
        {

            if (collider.CompareTag("TeamA"))
            {
                character.IGetDamage(attack);
            }

            // Si el collider pertenece al equipo B, le inflige daño
            if (collider.CompareTag("TeamB"))
            {
                characterIA.IGetDamage(attack);

            }
        }
    }

    Vector3 GetProbePosition()
    {
        // Devuelve la posición de la IA ajustada en el eje Y
        return actualTransform.position + actualTransform.TransformVector(new Vector3(0.0f, 1.2f, 0f));
    }
}
