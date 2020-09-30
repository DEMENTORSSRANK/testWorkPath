using System;
using Managers;
using UnityEngine;

namespace Menu
{
    public class HeroesItemsPanel : MonoBehaviour
    {
        [SerializeField] private Transform heroItemsParent;

        [SerializeField] private HeroItemUpdater heroItemPrefab;
        
        public void UpdatePanel()
        {
            ClearAllItems();

            var allHeroes = Managers.Managers.Values.Parameters.HeroesData;

            foreach (var hero in allHeroes)
            {
                var newItem = Instantiate(heroItemPrefab, heroItemsParent);
                
                newItem.InitHero(hero);
                
                newItem.gameObject.SetActive(true);
            }
        }

        private void ClearAllItems()
        {
            if (!heroItemsParent)
                return;
            
            if (!heroItemsParent.gameObject.activeSelf)
                return;
            
            if (heroItemsParent.childCount <= 0)
                return;

            for (var i = 0; i < heroItemsParent.childCount; i++)
            {
                Destroy(heroItemsParent.GetChild(i).gameObject);
            }
        }
    }
}