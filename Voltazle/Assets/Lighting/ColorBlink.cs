using UnityEngine;
using TMPro;

public class ColorBlink : MonoBehaviour
{
    public float blinkSpeed = 1.0f;
    public Color[] colors;
    private TextMeshProUGUI textMeshProComponent;
    private int currentColorIndex = 0;

    void Start()
    {
        textMeshProComponent = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("ChangeColor", 0, 1 / blinkSpeed);
    }

    void ChangeColor()
    {
        if (colors.Length == 0)
            return;

        textMeshProComponent.color = colors[currentColorIndex];

        currentColorIndex = (currentColorIndex + 1) % colors.Length;
    }
}
