using System;
using Addone;
using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class Values : SavePatch<Values.SaveData>
    {
        protected override string FileName { get; set; } = "values2";
        
        protected override SaveData SaveObject
        {
            get => saveVariables;
            set
            {
                saveVariables = value; 
                
                OnSomeValueChanged?.Invoke(value);
            }
        }

        public static UnityAction<SaveData> OnSomeValueChanged { get; set; }

        public LevelData CurrentLevel { get; set; }

        public SaveData Parameters => SaveObject;
        
        [SerializeField] private SaveData saveVariables;

        public static void UpdateValues()
        {
            OnSomeValueChanged.Invoke(Managers.Values.Parameters);
        }
        
        [Serializable]
        public class SaveData
        {
            [SerializeField] private int coins;
            
            [SerializeField] private HeroData[] heroesData = new HeroData[3];

            public int Coins
            {
                get => coins;

                set
                {
                    coins = value; 
                    
                    UpdateValues();
                }
            }
            
            public HeroData[] HeroesData
            {
                get => heroesData;
                set => heroesData = value;
            }

            public bool TryRemoveCoins(int value)
            {
                if (value > Coins)
                    return false;

                Coins -= value;
                
                UpdateValues();
                
                return true;
            }
        }

        [ContextMenu("Save")]
        private void DoSave()
        {
            Save();
        }

        private void Start()
        {
            OnSomeValueChanged += delegate(SaveData arg0)
            {
                Save();
            };
        }

        [Serializable]
        public class HeroData
        {
            [SerializeField] private Material material;

            [SerializeField] private int level;

            public Material Material => material;

            public float MoveSpeed => level + 1f;

            public int Level
            {
                get => level;
                set
                {
                    level = value; 
                    
                    UpdateValues();
                }
            }
        }
    }
}