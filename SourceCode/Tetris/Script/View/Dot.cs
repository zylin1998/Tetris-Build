using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tetris
{
    public class Dot : MonoBehaviour
    {
        public class Pool : MemoryPool<int, Transform, Dot> 
        {
            public Pool() 
            {
                DespawnRoot = new GameObject("DotPool").transform;
            }

            public Transform DespawnRoot { get; }

            protected override void Reinitialize(int id, Transform parent, Dot dot)
            {
                dot.Id = id;

                dot.gameObject.SetActive(true);

                dot.transform.SetParent(parent);
            }

            protected override void OnDespawned(Dot dot)
            {
                dot.transform.SetParent(DespawnRoot);
            }
        }

        [SerializeField]
        private Image _Image;
        [SerializeField]
        private Color _Empty;
        public int Type { get; set; }

        public int Id { get; set; }

        private void Awake()
        {
            Clear();
        }

        public void SetDot(Color color)
        {
            _Image.color = color;
        }

        public void Clear()
        {
            _Image.color = _Empty;
        }
    }
}