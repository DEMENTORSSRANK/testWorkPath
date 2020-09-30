using System;
using System.Linq;
using Addone;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuControl : MonoBehaviour
    {
        [SerializeField] private Button[] selectLevelButtons;

        [SerializeField] private TextMeshProUGUI coinsText;

        [SerializeField] private HeroesItemsPanel panel;

        private void OpenLevel(int index)
        {
            Managers.Managers.Values.CurrentLevel = LoadData.Levels[index];
            
            SceneManager.LoadScene("game");
        }

        private void Awake()
        {
            Values.OnSomeValueChanged += OnSomeValueChanged;
        }

        private void OnSomeValueChanged(Values.SaveData data)
        {
            coinsText.text = $"{data.Coins} COINS";
            
            panel.UpdatePanel();
        }

        private void Start()
        {
            // Init buttons
            for (var i = 0; i < selectLevelButtons.Length; i++)
            {
                var i1 = i;
                
                selectLevelButtons[i].onClick.AddListener(delegate
                {
                    OpenLevel(i1);
                });
            }
            
            OnSomeValueChanged(Managers.Managers.Values.Parameters);
        }
    }
}