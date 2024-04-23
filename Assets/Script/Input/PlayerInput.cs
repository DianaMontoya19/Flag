using UnityEngine;
using UnityEngine.UIElements;

// Clase que implementa la interfaz IMovable para controlar la entrada del jugador
public class PlayerInput : IMovable
{
    private readonly float _sensRotation; // Sensibilidad de la rotación
    private readonly Rigidbody _rb; // Componente Rigidbody del jugador
    private readonly Transform _transform; // Transform del jugador
    private readonly float _vel; // Velocidad del jugador
    private float _velX; // Velocidad en el eje X
    private float _velY; // Velocidad en el eje Y
    private bool _activeDirty; // Indica si el jugador está activo
    public bool _isAttacking; // Indica si el jugador está atacando
    private bool _mine = false; // Indica si el jugador tiene una mina
    private Vector3 _position = new Vector3(-2.17000008f, -6.42999983f, 57.7900009f);


    // Constructor de la clase
    public PlayerInput(float sensRotation, Rigidbody rb, Transform transform, float vel)
    {
        _sensRotation = sensRotation;
        _rb = rb;
        _transform = transform;
        _vel = vel;
    }

    // Este método se llama una vez por frame
    public void Update()
    {
        _velX = Input.GetAxis("Horizontal");
        _velY = Input.GetAxis("Vertical");
        ActivateDirty();
        Character.Instance.ActivateFoots(_activeDirty);
        Character.Instance.WalkAnimations(_velY, _velX);
        Character.Instance.AttackAnimations(AttackAnimations());
    }

    // Este método activa o desactiva la animación de caminar
    public void ActivateDirty()
    {
        _activeDirty = _velY > 0;
    }

    // Este método devuelve un número que representa el tipo de ataque
    public int AttackAnimations()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            return 2;
        }

        if (Input.GetMouseButtonDown(1))
        {
            return 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return 4;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            return 5;
        }

        return 0;
    }

    // Este método se llama en cada frame de física
    public void FixedUpdate()
    {
        if (!_isAttacking)
        {
            Vector3 movement = new Vector3(0f, 0f, _velY).normalized * _vel * Time.deltaTime;
            _transform.Translate(movement);

            float rotation = _velX * _sensRotation * Time.deltaTime;
            _transform.Rotate(0f, rotation, 0f);
        }
    }

    // Este método se llama cuando el objeto colisiona con otro objeto
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FlagObject flag))
        {
            FlagManager.Instance.CaptureFlag(Character.Instance.transform, true);
            _mine = true;
        }
        if(collision.gameObject.TryGetComponent(out Player iaPlayer))
        {
            var IA = CharacterIA.Instance;
            if(IA.health<=0)
            {
                IA.Die();
                iaPlayer.Desapear(_position);

                if (FlagManager.Instance.capturedBy == false)
                {
                    FlagManager.Instance.Spawn();
                }
            }
            
        }
    }
    // Este método se llama cuando el objeto deja de colisionar con otro objeto
    public void OnCollisionExit(Collision collision) { }

    // Este método se llama cuando el objeto entra en un trigger
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerFlag" && _mine)
        {
            FlagManager.Instance.Respawn();
            FlagManager.Instance.Point(Team.Blue);
            _mine = false;
        }
    }

    // Este método se llama cuando el objeto sale de un trigger
    public void OnTriggerExit(Collider other) {}

}