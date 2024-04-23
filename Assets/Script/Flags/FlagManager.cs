using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum FlagStatesEnum
{
    Point,
    Captured,
}

public class FlagManager : MonoBehaviour
{
    private readonly Team _team;
    private static FlagManager _instance;
    [SerializeField] private FlagObject _flagObject;
    [SerializeField] private Flag _flag;
    [SerializeField] private Transform _position;
    //[SerializeField] private Player _alive;
     public TextMeshProUGUI _teamBlue;
     public TextMeshProUGUI _teamRed;
     public TextMeshProUGUI _teamBlue_Menu;
     public TextMeshProUGUI _teamRed_Menu;
    public int _pointBlue = 0;
     public int _pointRed = 0;
    
    
    public static FlagManager Instance => _instance;

    //public Transform flagPosition;
    //public Transform flag;
    public FlagStatesEnum currentState;
    public bool capturedBy;

    private void Awake()
    {
        _instance = this;

    }
    private void Start()
    {
        _flagObject.Flags(_flag, _position);

    }
    
    public void CaptureFlag(Transform capturer, bool Captureby)
    {
        _position = capturer;
        capturedBy = Captureby;
        currentState = FlagStatesEnum.Captured;
        _flagObject.transform.parent = capturer;
        _flagObject.gameObject.SetActive(false);


    }
    public void Spawn()
    {
        _flagObject.transform.parent = null;
        _flagObject.transform.position = new Vector3(_position.transform.position.x + 3, _position.transform.position.y, _position.transform.position.z);
        //_flagObject.transform.position = new Vector3(1.44000006f, -12.6400003f, 7.11000013f);
        _flagObject.gameObject.SetActive(true);
        currentState = FlagStatesEnum.Point;

    }
    public void Respawn()
    {
        _flagObject.transform.parent = null;
        _flagObject.transform.position = new Vector3(6.03999996f, -12.6400003f, 7.11000013f);
        _flagObject.gameObject.SetActive(true);
        currentState = FlagStatesEnum.Point;
        
    }


    public void Point(Team team)
    {
        if (team == Team.Blue)
        {
            _pointBlue++;
            _teamBlue.text = "Flag Blue: " + _pointBlue.ToString("f0");
            _teamBlue_Menu.text = "Flag Blue: " + _pointBlue.ToString("f0");
            //Debug.Log("EQUIPO AZUL PUNTO" + _pointBlue);
        }
        else if (team == Team.Red)
        {
            _pointRed++;
            _teamRed.text = "Flag Red: " + _pointRed.ToString("f0");
            _teamRed_Menu.text = "Flag Red: " + _pointRed.ToString("f0");
        }
    }


}
