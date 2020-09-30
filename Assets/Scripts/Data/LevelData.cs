using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Game/Level Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private Vector2Int[] heroesPositions =
        {
            new Vector2Int(),
            new Vector2Int(),
            new Vector2Int(), 
        };

        [SerializeField] private ItemPositions[] itemPositions = new ItemPositions[3];

        public Vector2Int[] HeroesPositions => heroesPositions;

        public ItemPositions[] ItemsPositions => itemPositions;

        [Serializable]
        public struct ItemPositions
        {
            [SerializeField] private Vector2[] positions;

            public Vector2[] Positions => positions;
        }
    }
}
