
using UnityEngine;

[CreateAssetMenu(fileName = "New Character",menuName = "Character Data") ]
public class CharactersData : ScriptableObject
{
    [SerializeField] private GameObject _prefabCharacter;  

    public GameObject PrefabCharacter 
    { 
        get { return _prefabCharacter; } 
        set { _prefabCharacter = value; }
    }
}
