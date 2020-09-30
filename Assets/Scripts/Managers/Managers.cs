using System;
using Addone;
using UnityEngine;

namespace Managers
{
    public class Managers : MonoBehaviour
    {
        private static Managers _instance;
        
        public static Values Values { get; private set; }

        private void InitManagers()
        {
            Values = GetComponent<Values>();

            Values.CurrentLevel = LoadData.Levels[0];
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                
                return;
            }

            _instance = this;
            
            DontDestroyOnLoad(this);
            
            InitManagers();
        }
    }
}
