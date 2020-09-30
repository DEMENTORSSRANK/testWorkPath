using System;
using System.Collections;
using System.Linq;
using FieldDrawer;
using GameLogic;
using Hero;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeroesMove
{
    public class MoveAllHeroes : MonoBehaviour
    {
        public static MoveAllHeroes Instance;

        public void DoMoveAllHeroes()
        {
            StartCoroutine(WaitMovingAllHeroes());
        }

        private void Awake()
        {
            Instance = this;
        }

        private IEnumerator WaitMovingAllHeroes()
        {
            var allHeroes = SpawnLevelData.Instance.CurrentHeroes.Select(x => 
                x.GetComponent<HeroMover>());

            var heroMovers = allHeroes as HeroMover[] ?? allHeroes.ToArray();
            
            foreach (var hero in heroMovers)
            {
                var myPath = FieldDraw.Instance.GetPathWithMaterial(hero.Material);
                
                hero.MoveTo(myPath);
            }
            
            yield return new WaitUntil(() => heroMovers.All(x => !x.IsMove));

            SceneManager.LoadScene("menu");
        }
    }
}