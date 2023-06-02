using System;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private int _obstacleCount;
        [SerializeField] private Transform _parent;

        public int ObstacleCount => _obstacleCount;

        private void Start()
        {
            Transform parentTransform = _parent.transform;
            Vector3 newScale = parentTransform.localScale;
            newScale.y = _obstacleCount;
            parentTransform.localScale = newScale;
        }
    }
}