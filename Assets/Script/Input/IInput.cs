using UnityEngine;

public interface IMovable
{
    void FixedUpdate(); // Este método se llama en cada frame de física
    void Update(); // Este método se llama una vez por frame
    int AttackAnimations(); // Este método devuelve un número que representa el tipo de ataque
    void ActivateDirty(); // Este método activa o desactiva la animación de caminar
    void OnCollisionEnter(Collision collision); // Este método se llama cuando el objeto colisiona con otro objeto
    void OnCollisionExit(Collision collision); // Este método se llama cuando el objeto deja de colisionar con otro objeto
    void OnTriggerEnter(Collider other); // Este método se llama cuando el objeto entra en un trigger
    void OnTriggerExit(Collider other); // Este método se llama cuando el objeto sale de un trigger
}