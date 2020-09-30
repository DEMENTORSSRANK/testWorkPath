using System;
using System.Collections.Generic;
using System.Linq;
using Field.Cell;
using GameLogic;
using Hero;
using UnityEngine;
using UnityEngine.Events;

namespace FieldDrawer
{
    public class FieldDraw : MonoBehaviour
    {
        [SerializeField] private List<HeroPath> heroPaths;

        [SerializeField] private List<CellController> currentCells;
        
        private HeroMover _currentHero;

        private bool _gotPress;
        
        public UnityAction<HeroMover> OnHeroDown;

        public UnityAction<HeroMover> OnHeroUp;

        public UnityAction<CellController> OnCellEnter;

        public UnityAction OnRightDraw;

        public static FieldDraw Instance;

        public HeroPath GetPathWithMaterial(Material material)
        {
            var found = heroPaths.Find(x => x.material.color == material.color);
         
            print(found.cells.Count);
            
            return found;
        }

        private void OnEnterCell(CellController cell)
        {
            if (_currentHero == null || _gotPress)
                return;

            cell.Material = _currentHero.Material;
            
            currentCells.Add(cell);
        }

        private void OnDown(HeroMover hero)
        {
            if (_gotPress)
                return;
            
            _currentHero = hero;

            if (heroPaths.Any(x => x.material == hero.Material))
            {
                var found = heroPaths.Find(x => x.material == hero.Material);
                
                found.cells.ForEach(x => x.SetToDefaultMaterial());
                
                heroPaths.Remove(found);
            }
        }

        private void OnUp(HeroMover hero)
        {
            if (_gotPress)
                return;
            
            _currentHero = null;
            
            heroPaths.Add(new HeroPath()
            {
                material = hero.Material,
                cells = currentCells.ToList()
            });
            
            currentCells.Clear();
            
            if (!SpawnLevelData.Instance.IsAllItemsComplete)
                return;

            _gotPress = true;
            
            OnRightDraw.Invoke();
        }

        private void Awake()
        {
            Instance = this;
            
            OnHeroDown += OnDown;
            
            OnHeroUp += OnUp;
            
            OnCellEnter += OnEnterCell;
        }

        [Serializable]
        public struct HeroPath
        {
            public Material material;

            public List<CellController> cells;
        }
    }
}