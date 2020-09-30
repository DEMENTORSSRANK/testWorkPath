using System;
using FieldDrawer;
using UnityEngine;

namespace Field.Cell
{
    public class CellController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        [SerializeField] private Material defaultMaterial;
        
        public Material Material
        {
            get => meshRenderer.material;

            set => meshRenderer.material = value;
        }

        public void SetToDefaultMaterial()
        {
            Material = defaultMaterial;
        }
        
        private void OnMouseEnter()
        {
            FieldDraw.Instance.OnCellEnter.Invoke(this);
        }
    }
}