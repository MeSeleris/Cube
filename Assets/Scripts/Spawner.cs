using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Handler _handler;
    [SerializeField] private Cube _prefabToSpawn;
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _transform;

    private int _spawnMin = 2;
    private int _spawnMax = 6;
    private int _currentSpawn;

    private void Start()
    {
        Cube spawnedCube = Instantiate(_prefabToSpawn, _transform.position, transform.rotation);
    }

    private void OnEnable()
    {
        _handler.Spawn += Spawn;
    }
    private void OnDisable()
    {
        _handler.Spawn -= Spawn;
    }

    private void Spawn(Cube cube)
    {
        _currentSpawn = UnityEngine.Random.Range(_spawnMin, _spawnMax + 1);

        for (int i = 0; i < _currentSpawn; i++)
        {
            Vector3 spawnPosition = transform.position;
            Quaternion spawnRotation = Quaternion.identity;

            Cube spawnedCube = Instantiate(_prefabToSpawn, spawnPosition, spawnRotation);

            Vector3 newScale = DivideScale();
            spawnedCube.transform.localScale = newScale;

            spawnedCube.GetComponent<Cube>().enabled = true;
        }
    }

    private Vector3 DivideScale()
    {
        Vector3 scale = transform.localScale / 2f;

        return scale;
    }
}
