using System;
using System.Collections.Generic;
using System.Linq;
using Field;
using Hero;
using Item;
using UnityEngine;

namespace GameLogic
{
    public class SpawnLevelData : MonoBehaviour
    {
        [SerializeField] private HeroController heroPrefab;

        [SerializeField] private ItemController itemPrefab;

        [SerializeField] private Transform parentHeroes;

        [SerializeField] private Transform parentItems;

        [SerializeField] private List<ItemController> currentItems;

        [SerializeField] private List<HeroController> currentHeroes;

        public bool IsAllItemsComplete => currentItems.All(x => x.UnderMaterialRight);

        public List<HeroController> CurrentHeroes => currentHeroes;

        public static SpawnLevelData Instance;

        private void SpawnRightLevel()
        {
            var rightData = Managers.Managers.Values.CurrentLevel;

            var allHeroes = Managers.Managers.Values.Parameters.HeroesData;

            // Spawn heroes
            var heroesPositions = rightData.HeroesPositions;

            for (var i = 0; i < allHeroes.Length; i++)
            {
                var heroData = allHeroes[i];

                var heroPosition = heroesPositions[i];

                var setHeroPosition = (Vector2) heroPosition;
                
                setHeroPosition += new Vector2(.5f, .5f);
                
                var hero = Instantiate(heroPrefab, parentHeroes);
                
                hero.InitHero(heroData);
                
                // Set current position
                var heroTransform = hero.transform;

                var currentPosition = heroTransform.position;

                currentPosition.x = setHeroPosition.x;

                currentPosition.z = setHeroPosition.y;

                heroTransform.position = currentPosition;
                
                currentHeroes.Add(hero);
            }
            
            // Spawn items
            var itemsPositions = rightData.ItemsPositions;

            for (var i = 0; i < itemsPositions.Length; i++)
            {
                var curPositions = itemsPositions[i].Positions;

                foreach (var t in curPositions)
                {
                    var newItem = Instantiate(itemPrefab, parentItems);

                    var position = t;

                    newItem.Material = allHeroes[i].Material;
                    
                    position += new Vector2(.5f, .5f);

                    var itemTransform = newItem.transform;

                    var currentPosition = itemTransform.position;

                    currentPosition.x = position.x;

                    currentPosition.z = position.y;

                    itemTransform.position = currentPosition;
                    
                    newItem.InitUnderCell();
                    
                    currentItems.Add(newItem);
                }
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SpawnRightLevel();
        }
    }
}