using System;
using System.Collections.Generic;
using System.Linq;
using FieldDrawer;
using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(HeroController))]
    public class HeroMover : MonoBehaviour
    {
        [SerializeField] private List<Vector3> points;

        private HeroController _heroController;

        private int _indexMove;

        public bool IsMove { get; private set; }

        public Material Material => _heroController.Material;

        public void MoveTo(FieldDraw.HeroPath path)
        {
            foreach (var cell in path.cells)
            {
                var cellPosition = cell.transform.position;
                
                points.Add(new Vector3(cellPosition.x, transform.position.y, cellPosition.z));
            }

            IsMove = true;
        }

        private void CheckMove()
        {
            if (!IsMove)
                return;

            var position = transform.position;

            var target = points[_indexMove];

            position = Vector3.MoveTowards(position, target, 
                _heroController.MoveSpeed * Time.deltaTime);

            transform.position = position;

            if (position == target)
            {
                _indexMove++;

                if (_indexMove >= points.Count)
                {
                    IsMove = false;
                }
            }
        }

        private void OnMouseDown()
        {
            FieldDraw.Instance.OnHeroDown?.Invoke(this);
        }

        private void OnMouseUp()
        {
            FieldDraw.Instance.OnHeroUp?.Invoke(this);
        }

        private void Awake()
        {
            _heroController = GetComponent<HeroController>();
        }

        private void FixedUpdate()
        {
            CheckMove();
        }
    }
}