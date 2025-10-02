using System;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> SpawnCube;

    private void OnEnable()
    {
        _raycaster.Ray += Explosion;
    }
    private void OnDisable()
    {
        _raycaster.Ray -= Explosion;
    }

    private void Explosion(Cube cube)
    {
        int examinationNum = UnityEngine.Random.Range(0 , cube.ChanceMax);

        if(examinationNum < cube.CurrentChance)
        {
            SpawnCube?.Invoke(cube);
        }

        Destroy(cube.gameObject);
    }
}
