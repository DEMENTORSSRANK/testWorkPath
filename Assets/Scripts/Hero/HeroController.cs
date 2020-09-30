using Managers;
using UnityEngine;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        public Material Material => meshRenderer.material;
        
        private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;

        public void InitHero(Values.HeroData hero)
        {
            meshRenderer.material = hero.Material;

            _moveSpeed = hero.MoveSpeed;
        }
    }
}