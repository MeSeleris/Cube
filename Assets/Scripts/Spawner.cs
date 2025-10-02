using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Handler _handler;
    [SerializeField] private Cube _prefabToSpawn;
    [SerializeField] private Transform _transform;

    private int _spawnMin = 2;
    private int _spawnMax = 6;


    private void Start()
    {
        Cube spawnedCube = Instantiate(_prefabToSpawn, _transform.position, transform.rotation);
    }

    private void OnEnable()
    {
        _handler.SpawnCube += Spawn;
    }
    private void OnDisable()
    {
        _handler.SpawnCube -= Spawn;
    }

    private void Spawn(Cube cube)
    {
        int _currentSpawn = Random.Range(_spawnMin, _spawnMax + 1);
        int parentCurrentChance = cube.CurrentChance;

        for (int i = 0; i < _currentSpawn; i++)
        {
            Vector3 spawnPosition = cube.transform.position;
            Quaternion spawnRotation = Quaternion.identity;

            Cube spawnedCube = Instantiate(_prefabToSpawn, spawnPosition, spawnRotation);
            Cube spawnedCubeScript = spawnedCube.GetComponent<Cube>();
            spawnedCubeScript.SetChildChance(parentCurrentChance);

            Vector3 newScale = DivideScale(cube);
            spawnedCube.transform.localScale = newScale;

            spawnedCubeScript.enabled = true;
        }
    }

    private Vector3 DivideScale(Cube cube)
    {
        Vector3 scale = cube.transform.localScale / 2f;

        return scale;
    }
}
