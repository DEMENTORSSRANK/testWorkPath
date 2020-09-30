using System;
using UnityEngine;

namespace Field.Cell
{
    [RequireComponent(typeof(CellController))]
    public class CellMover : MonoBehaviour
    {
        private CellController _controller;

        private void Awake()
        {
            _controller = GetComponent<CellController>();
        }
    }
}