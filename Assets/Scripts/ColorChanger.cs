using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        Color randomColor = new Color (Random.value, Random.value, Random.value);
        
        GetComponent<Renderer>().material.color = randomColor;
    }
}
