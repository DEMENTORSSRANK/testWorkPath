using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class HeroItemUpdater : MonoBehaviour
    {
        [SerializeField] private Image avatarImage;
        
        [SerializeField] private Button upgradeButton;

        [SerializeField] private TextMeshProUGUI currentLevelText;

        public void InitHero(Values.HeroData data)
        {
            avatarImage.color = data.Material.color;

            currentLevelText.text = $"LEVEL {data.Level + 1}/3";

            var canUpgrade = data.Level < 2;

            upgradeButton.interactable = canUpgrade;
            
            upgradeButton.onClick.RemoveAllListeners();
            
            if (!canUpgrade)
                return;
            
            upgradeButton.onClick.AddListener(delegate
            {
                Upgrade(data);
            });
        }

        private void Upgrade(Values.HeroData data)
        {
            if (!Managers.Managers.Values.Parameters.TryRemoveCoins(5))
                return;

            data.Level++;
        }
        
    }
}