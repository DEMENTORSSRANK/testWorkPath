using System;
using Field;
using Field.Cell;
using UnityEngine;

namespace Item
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        private CellController _underCell;
        
        public Material Material
        {
            get => meshRenderer.material;

            set => meshRenderer.material = value;
        }

        public bool UnderMaterialRight => _underCell.Material.color == Material.color;

        public void InitUnderCell()
        {
            _underCell = FieldControl.Instance.GetCellWithPosition(transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}