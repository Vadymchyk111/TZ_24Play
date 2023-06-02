using System;
using System.Collections.Generic;
using System.Linq;
using Cubes;
using Obstacle;
using UnityEngine;

namespace Player
{
    public class PlayerCubeHolder : MonoBehaviour
    {
        public event Action OnLastCubeDetached;
        
        [SerializeField] private List<CollectableCube> _collectableCubes;
        [SerializeField] private float _cubeHeight;
        [SerializeField] private Transform _stickmanTransform;
        [SerializeField] private BoxCollider _boxCollider;

        private bool _isColliding;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CollectableCube collectableCube))
            {
                AttachCube(collectableCube);
            }

            if (!other.transform.TryGetComponent(out ObstacleController obstacleController) || _isColliding)
            {
                return;
            }
            
            _isColliding = true;
            DetachCube(obstacleController.ObstacleCount);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.TryGetComponent(out ObstacleController obstacleController))
            {
                _isColliding = false;
            }
        }

        private void AttachCube(CollectableCube collectableCube)
        {
            collectableCube.GetComponent<BoxCollider>().enabled = false;
            Vector3 cubePosition = _collectableCubes.Last().transform.position;
            cubePosition.y += _cubeHeight / 2f;
            Vector3 stickPosition = _stickmanTransform.position;
            stickPosition.y += _cubeHeight / 2f;
            _stickmanTransform.position = stickPosition;
            collectableCube.transform.position = cubePosition;
            collectableCube.transform.SetParent(gameObject.transform);
            _collectableCubes.Add(collectableCube);
        }

        private void DetachCube(int obstacleCount)
        {
            for (int i = 0; i < obstacleCount; i++)
            {
                CollectableCube collectableCube = _collectableCubes.FirstOrDefault();
                
                if (collectableCube is null)
                {
                    return;
                }
                
                _collectableCubes.Remove(collectableCube);
                collectableCube.gameObject.transform.SetParent(null);
                
                if (_collectableCubes.Count == 0)
                {
                    OnLastCubeDetached?.Invoke();
                    enabled = false;
                    return;
                }
                
                _boxCollider.center = _collectableCubes.First().transform.localPosition;
                GetComponent<BoxCollider>().center = _collectableCubes.First().transform.localPosition;
            }
        }
    }
}