using System;
using FieldDrawer;
using HeroesMove;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUi
{
    public class MainInterface : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText;

        [SerializeField] private Button playButton;
        
        private void Awake()
        {
            Values.OnSomeValueChanged += OnSomeValueChanged;
            
            FieldDraw.Instance.OnRightDraw += OnRightDraw;
        }

        private void OnRightDraw()
        {
            playButton.interactable = true;
        }

        private void Start()
        {
            playButton.interactable = false;
            
            playButton.onClick.AddListener(OnPlayClick);

            OnSomeValueChanged(Managers.Managers.Values.Parameters);
        }

        private void OnPlayClick()
        {
            Managers.Managers.Values.Parameters.Coins += 15;
            
            playButton.interactable = false;
            
            MoveAllHeroes.Instance.DoMoveAllHeroes();
        }
        
        private void OnSomeValueChanged(Values.SaveData arg0)
        {
            coinsText.text = arg0.Coins + " COINS";
        }
    }
}