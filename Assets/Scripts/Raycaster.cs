using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputViewCube _input;

    private Ray _ray;
    private RaycastHit _hit;
    
    public event UnityAction<Cube> Find;

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

        if(Physics.Raycast(_ray, out _hit))
        {
            Debug.Log($"Попал в: {_hit.collider.gameObject.name}");
            Debug.DrawRay(_ray.origin, _ray.direction * _hit.distance, Color.red, 0.1f);

            Cube hitCube = _hit.collider.GetComponent<Cube>();
            
            if( hitCube != null)
            {
                Find?.Invoke(hitCube);
            }
        }
    }
}
