using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputViewCube _input;

    private Ray _ray;
    private RaycastHit _hit;
    
    public event UnityAction<Cube> Ray;

    private void OnEnable()
    {
        _input.Click += RayHit;
    }

    private void OnDisable()
    {
        _input.Click -= RayHit;
    }

    private void RayHit()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log($"Clic11111k");
        if (Physics.Raycast(_ray, out _hit))
        {
            Debug.Log($"Попал в: {_hit.collider.gameObject.name}");
            Debug.DrawRay(_ray.origin, _ray.direction * _hit.distance, Color.red, 0.1f);
            
            if(_hit.collider.TryGetComponent(out Cube cube))
            {
                Ray?.Invoke(cube);
            }
        }
    }
}
