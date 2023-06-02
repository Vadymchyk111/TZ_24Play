using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform _trackPrefab;
        [SerializeField] private Transform _obstaclePrefab;
        [SerializeField] private Transform _cubePrefab;
        [SerializeField] private Transform _trackSpawnPoint;
        [SerializeField] private List<Transform> _obstacleSpawnPoints;
        [SerializeField] private List<Transform> _cubeSpawnPoints;
        [SerializeField] private float _spawnInterval;

        private WaitForSeconds _waitForSeconds;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_spawnInterval);
            StartCoroutine(SpawnObjects());
        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                Instantiate(_trackPrefab, transform.position, Quaternion.identity);
                Instantiate(_obstaclePrefab, transform.position, Quaternion.identity);
                Instantiate(_cubePrefab, transform.position, Quaternion.identity);
                
                

                yield return _waitForSeconds;
            }
        }
    }
}