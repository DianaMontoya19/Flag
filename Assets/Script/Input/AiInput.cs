using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.UIElements;
using System.Collections;

// Enumeración que define los estados posibles de la IA
[Serializable]
public enum EnemyStateEnum
{
    Player,
    Flag,
    Position,
}

// Clase que implementa la interfaz IMovable para controlar la IA
public class AiInput : IMovable
{
    private readonly Team _team; // El equipo al que pertenece la IA
    private readonly Dictionary<EnemyStateEnum, Transform> _positions; // Diccionario que almacena las posiciones de interés para la IA
    private readonly NavMeshAgent _agent; // Agente de navegación de la IA
    public NavMeshAgent Agent=> _agent;
    private EnemyStateEnum _currentState; // Estado actual de la IA
    private bool _isActive = false; // Indica si la IA está activa
    private int RangeAttack; // Rango de ataque de la IA
    private Vector3 _position = new Vector3(6.47670412f, -6.44882298f, -14.8500004f);

    // Propiedad que devuelve el estado de la IA dependiendo de si ha capturado la bandera o no
    private EnemyStateEnum IsFlagCaptured =>
        FlagManager.Instance.currentState == FlagStatesEnum.Captured && _isActive
            ? EnemyStateEnum.Position
            : EnemyStateEnum.Flag;

    // Constructor de la clase
    public AiInput(Team team, Dictionary<EnemyStateEnum, Transform> positions, NavMeshAgent agent, EnemyStateEnum currentState = EnemyStateEnum.Flag)
    {
        _team = team;
        _positions = positions;
        _agent = agent;
        _currentState = currentState;
    }

    // Este método se llama cuando la IA colisiona con otro objeto
    public void OnCollisionEnter(Collision collision)
    {
        // Si el objeto con el que colisiona es una bandera, la captura
        if (collision.gameObject.TryGetComponent(out FlagObject flag))
        {
            _isActive = true;
            FlagManager.Instance.CaptureFlag(CharacterIA.Instance.transform, false); // Captura la bandera
            _currentState = IsFlagCaptured; // Cambia el estado del AI
        }
        // Si el objeto con el que colisiona es un jugador, cambia el estado de la IA
        if (collision.gameObject.TryGetComponent(out Player play))
        {
            var player = Character.Instance;
            CharacterIA.Instance.AttackAnimations(AttackAnimations());
                   
            if(player.health <=0)
            {
                player.Die();
                play.Desapear(_position);
                //player.Life();

                _currentState = IsFlagCaptured;


                if (FlagManager.Instance.capturedBy)
                {
                    FlagManager.Instance.Spawn();
                }
            }


        }
        // Si el objeto con el que colisiona es la bandera del enemigo y la IA tiene la bandera, la respawnea y suma un punto
        if(collision.gameObject.CompareTag("EnemyFlag") && _isActive)
        {
            FlagManager.Instance.Respawn();
            FlagManager.Instance.Point(Team.Red);
            _currentState = IsFlagCaptured;
            _isActive = false;
        }
    }

    // Este método se llama cuando la IA deja de colisionar con otro objeto
    public void OnCollisionExit(Collision collision) { }

    // Este método se llama cuando la IA entra en un trigger
    public void OnTriggerEnter(Collider other)
    {
        
        if (!other.gameObject.TryGetComponent(out Player player)) return;
        _positions[EnemyStateEnum.Player] = player.transform;
        _currentState = EnemyStateEnum.Player;
    }

    // Este método se llama cuando la IA sale de un trigger
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _currentState = IsFlagCaptured;
        }
    }

    // Este método mueve la IA hacia el estado actual
    private void Move(EnemyStateEnum state)
    {
        Transform destine = _positions[state];
        _agent.SetDestination(destine.position);
       
    }

    // Este método se llama en cada frame de física
    public void FixedUpdate()
    {
        Move(_currentState);
    }

    // Este método se llama una vez por frame
    public void Update()
    {
        float _velx = 1f;
        CharacterIA.Instance.WalkAnimationsIA(_velx);
    }

    // Este método devuelve un número aleatorio entre 0 y 2
    public int AttackAnimations()
    {
        RangeAttack =  Random.Range(0, 2);
        return 0;
    }

    // Este método no hace nada en esta clase, pero está aquí para cumplir con la interfaz IMovable
    public void  ActivateDirty()
    {
    }
    

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(1f);
    //}
}