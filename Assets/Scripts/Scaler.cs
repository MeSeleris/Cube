using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleSpeed = new Vector3(0f, 0f, 0f);

    private void Update()
    {
        Vector3 newScale = transform.localScale + _scaleSpeed * Time.deltaTime;

        transform.localScale = newScale;
    }
}
