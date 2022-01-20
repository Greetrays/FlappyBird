using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _delay;

    private float _elepsedTime;

    private void Start()
    {
        Initial(_template);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            if (TryGetObject(out GameObject pipe))
            {
                Vector3 spawnPoint = new Vector3(transform.position.x, Random.Range(_minDistance, _maxDistance), transform.position.z);
                Spawn(pipe, spawnPoint);
            }

            _elepsedTime = 0;
        }
    }

    private void Spawn(GameObject pipe, Vector3 spawnPoint)
    {
        pipe.SetActive(true);
        pipe.transform.position = spawnPoint;
        DisableObjectAbroadScreen();
    }
}
