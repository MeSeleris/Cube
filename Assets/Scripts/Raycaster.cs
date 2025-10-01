using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputViewCube _input;

    private Ray _ray;
    private RaycastHit _hit;

    public event Action<Cube> Ray;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                //Debug.Log($"Попал в: {_hit.collider.gameObject.name}");
                Debug.DrawRay(_ray.origin, _ray.direction * _hit.distance, Color.red, 0.1f);

                if (_hit.collider.TryGetComponent(out Cube cube))
                {
                    Debug.Log(cube.gameObject.name);
                    Ray?.Invoke(cube);
                }
            }
        }
    }
}
