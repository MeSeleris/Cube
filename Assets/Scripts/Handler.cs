using System;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> Spawn;
    public event Action Destroyer;

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
        int examinationNum = UnityEngine.Random.Range(0 , _cube.ChanceMax);

        if(examinationNum < _cube.ChanceMax )
        {
            Spawn?.Invoke(cube);
        }

        Destroyer?.Invoke();
    }
}
