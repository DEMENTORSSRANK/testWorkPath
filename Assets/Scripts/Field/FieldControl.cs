using System;
using System.Collections.Generic;
using System.Linq;
using Field.Cell;
using UnityEngine;

namespace Field
{
    public class FieldControl : MonoBehaviour
    {
        [SerializeField] private Vector2 fieldSize;

        [SerializeField] private GameObject cellPrefab;

        [SerializeField] private Transform cellsParent;

        [SerializeField] private float cellsOffset = .5f;

        [SerializeField] private List<Transform> allCells = new List<Transform>();

        public static FieldControl Instance;

        public CellController GetCellWithPosition(Vector3 position)
        {
            var posFind = position;

            posFind.y = 0;
            
            return allCells.Find(x => x.position == posFind).GetComponent<CellController>();
        }

        [ContextMenu("Init field")]
        private void InitField()
        {
            ClearField();

            var xCount = fieldSize.x;

            var yCount = fieldSize.y;
            // Set to start position
            var startPosition = new Vector2(-xCount + cellsOffset, -yCount + cellsOffset);

            var halfSet = new Vector2(Mathf.FloorToInt(xCount / 2), Mathf.FloorToInt(yCount / 2));

            startPosition += halfSet;

            var currentPosition = startPosition;

            for (var x = 0; x < xCount; x++)
            {
                for (var y = 0; y < yCount; y++)
                {
                    var pos = new Vector3(currentPosition.x, 0, currentPosition.y);

                    var cell = Instantiate(cellPrefab, pos, Quaternion.identity, cellsParent);

                    currentPosition.y++;

                    allCells.Add(cell.transform);
                }

                currentPosition.x++;

                currentPosition.y = startPosition.y;
            }
        }

        private void ClearField()
        {
            allCells.Clear();

            if (cellsParent.childCount <= 0)
                return;

            var allChildren = new List<GameObject>();

            for (var i = 0; i < cellsParent.childCount; i++)
            {
                allChildren.Add(cellsParent.GetChild(i).gameObject);
            }

            allChildren.ForEach(DestroyImmediate);
        }

        private void Awake()
        {
            Instance = this;

            InitField();
        }
    }
}