using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.5f;  // Intensitas minimum
    public float maxIntensity = 15.51f;  // Intensitas maksimum
    public float flickerSpeed = 1.0f; // Kecepatan kedipan

    private Light2D _light2D;
    private float _randomOffset;

    void Start()
    {
        _light2D = GetComponent<Light2D>();
        _randomOffset = Random.Range(0.0f, 100.0f); // Untuk variasi kedipan yang berbeda
    }

    void Update()
    {
        // Menggunakan sinusoid untuk membuat efek kedipan
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * flickerSpeed + _randomOffset) + 1.0f) / 2.0f);
        _light2D.intensity = intensity;
    }
}
