using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabToSpawn;
    [SerializeField] private Cube _cube;

    private int _spawnMin = 2;
    private int _spawnMax = 6;
    private int _currentSpawn;
    private int _spawnCount = 1;

    private void OnEnable()
    {
        _cube.Spawn += Spawn;
    }
    private void OnDisable()
    {
        _cube.Spawn -= Spawn;
    }

    private void Spawn()
    {
        _currentSpawn = Random.Range(_spawnMin, _spawnMax + 1);

        for(int i = 0; i < _currentSpawn; i++)
        {
            Vector3 spawnPosition = GetRandomAxis();
            Quaternion spawnRotation = Quaternion.identity;

            Cube spawnedCube = Instantiate(_prefabToSpawn, spawnPosition, spawnRotation);
            _cube.Initialize(_spawnCount);

            Vector3 newScale = DivideScale();
            spawnedCube.transform.localScale = newScale;

            spawnedCube.GetComponent<Cube>().enabled = true;
            spawnedCube.Initialize(_spawnCount);
        }

        _spawnCount++;
    }

    private Vector3 DivideScale()
    {
        Vector3 scale = transform.localScale / 2f;

        return scale;
    }

    private Vector3 GetRandomAxis()
    {
        Vector3 currentPosition = transform.position;

        int posX = 0;
        int posY = 1;
        int posZ = 2;

        int randomRange = 10;

        int axis = Random.Range(posX, posZ + 1);
        float offset = Random.Range(posX, randomRange + 1);

        if (axis == posX)
            currentPosition.x += offset;
        else if (axis == posY)
            currentPosition.y += offset;
        else
            currentPosition.z += offset;       

        return currentPosition;
    }
}
