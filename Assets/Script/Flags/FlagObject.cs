using UnityEngine;

public  class FlagObject : MonoBehaviour
{
    //private static FlagObject _instance; // Instancia estática de la clase FlagObject
    //public static FlagObject Instance => _instance; // Propiedad para acceder a la instancia estática
    public bool follow = false; // Variable que indica si la bandera debe seguir al jugador
    private FlagObject _flag; // Referencia a la bandera
    private Transform _transform; // Referencia al componente Transform de la bandera

    protected void Awake()
    {
        //_instance = this; // Asigna la instancia actual a la variable estática _instance
        _transform = transform; // Asigna el componente Transform a la variable _transform
    }

    public void Flags(FlagObject flag, Transform transform)
    {
        // Crea una nueva instancia de la bandera en la posición del objeto transform
        _flag = Instantiate(flag, transform);
    }
}

