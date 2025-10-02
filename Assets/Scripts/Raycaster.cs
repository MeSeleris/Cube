using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
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
                if (_hit.collider.TryGetComponent(out Cube cube))
                {
                    Debug.Log(cube.gameObject.name);
                    Ray?.Invoke(cube);
                }
            }
        }
    }
}
