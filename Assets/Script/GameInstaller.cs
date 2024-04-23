using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Player enemy;
        [SerializeField] private CharactersData characterData;

        [SerializeField] private Character[] character;
        [SerializeField] private CharacterIA[] characterEnemy;

        [SerializeField] private EnemyStateEnum[] enums;
        [SerializeField] private Transform[] transforms;

        [SerializeField] private Transform position;
        private string[] names = { "Knight", "Barbarian", "Skeleton_Warrior" ,"Skeleton_Minion",};
        private Dictionary<EnemyStateEnum, Transform> _positions = new();
        
        private void Awake()
        {
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i], transforms[i] );
            }

        }

        private void Start()
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == characterData.PrefabCharacter.name)
                {
                    IMovable movable = new PlayerInput(600f, player.Rb, player.Transform, 5f);
                    IMovable movalbeEnemy = new AiInput(Team.Red, _positions, enemy.NavMeshAgent, EnemyStateEnum.Flag);
                    player.Configure(Team.Blue, character[i], movable);
                    enemy.ConfigureEnemy(Team.Red, characterEnemy[i], movalbeEnemy);
                    break;
                }
            }
        }   
    
    }
}