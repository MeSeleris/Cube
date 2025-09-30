using UnityEngine;
using UnityEngine.Events;

public class ViewCube : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    public event UnityAction<Cube> Find;

    private void OnEnable()
    {
        _raycaster.Ray += FindCube;
    }

    private void OnDisable()
    {
        _raycaster.Ray -= FindCube;
    }

    private void FindCube(Cube cube)
    {
        Find?.Invoke(cube);
    }
}
