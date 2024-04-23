using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

// Enumeración que define los equipos posibles
[Serializable]
public enum Team
{
    Blue,
    Red,
}

// Clase que controla el comportamiento del jugador
public class Player : MonoBehaviour
{
    private Team _team; // El equipo al que pertenece el jugador
    public Team Team => _team;
    private Character _character; // El personaje del jugador
    private CharacterIA _characterEnemy; // El enemigo del jugador
    private IMovable _movable; // La entrada del jugador

    private Rigidbody _rb; // Componente Rigidbody del jugador
    public Rigidbody Rb => _rb;
    private Transform _transform; // Transform del jugador
    public Transform Transform => _transform;
    private NavMeshAgent _navMeshAgent; // Agente de navegación del jugador
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    // Este método se llama cuando el script se carga
    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Este método configura el jugador
    public void Configure(Team team, Character character, IMovable movable)
    {
        _team = team;
        _character = Instantiate(character, _transform);
        _movable = movable;
    }

    // Este método configura el enemigo del jugador
    public void ConfigureEnemy(Team team, CharacterIA characterEne, IMovable movable)
    {
        _team = team;
        _characterEnemy = Instantiate(characterEne, _transform);
        _movable = movable;
    }

    // Este método se llama una vez por frame
    public void Update()
    {
        _movable.Update();
    }

    // Este método se llama en cada frame de física
    protected void FixedUpdate()
    {
        _movable.FixedUpdate();
    }

    // Este método se llama cuando el objeto colisiona con otro objeto
    private void OnCollisionEnter(Collision other)
    {
        _movable.OnCollisionEnter(other);
    }

    // Este método se llama cuando el objeto deja de colisionar con otro objeto
    private void OnCollisionExit(Collision other)
    {
        _movable.OnCollisionExit(other);
    }

    // Este método se llama cuando el objeto entra en un trigger
    private void OnTriggerEnter(Collider other)
    {
        _movable.OnTriggerEnter(other);
    }

    // Este método se llama cuando el objeto sale de un trigger
    private void OnTriggerExit(Collider other)
    {
        _movable.OnTriggerExit(other);
    }

    // Este método mata al jugador
    public void Desapear(Vector3 position)
    {

        StartCoroutine(Timer(position));
        
    }
    IEnumerator Timer(Vector3 position)
    {
        yield return new WaitForSeconds(2f);

        transform.position = position;
        
    }

}