using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    private int _chanceMax = 100;
    private int _currentChance = 100;
    private float _reductionFactor = 2f;

    public event UnityAction Spawn;

    public void Initialize(int spawnCount)
    {
        _currentChance = (int)(_chanceMax / Mathf.Pow(_reductionFactor, spawnCount - 1));
    }

    private void OnEnable()
    {
        _raycaster.Find += CubeDivider;
    }

    private void OnDisable()
    {
        _raycaster.Find -= CubeDivider;
    }

    private void CubeDivider(Cube cube)
    {
        if(cube != this)
            return;

        int currentNumber = Random.Range(0, _chanceMax + 1);

        if (currentNumber < _currentChance)
        {
            Spawn?.Invoke();
        }

        Destroy(gameObject);
    }
}
