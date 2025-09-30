using UnityEngine;
using UnityEngine.Events;

public class InputViewCube : MonoBehaviour
{
    private const int CommandPressButton = 0;

    public event UnityAction Click;

    private void Update()
    {
        if (Input.GetMouseButtonDown(CommandPressButton))
        {
            Debug.Log($"Click");
            Click?.Invoke();
        }
    }
}