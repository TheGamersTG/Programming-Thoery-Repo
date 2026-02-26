using UnityEngine;
using UnityEngine.UI;

public class GivMeter : MonoBehaviour
{

    private Slider slider;

    private float FillSpeed = 0.25f;

    private float targetProcess = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProcess)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public void UpdateSlider(float update)
    {
        targetProcess = slider.value + update;
    }

    public void resetSlider()
    {
        slider.value = 0;
        targetProcess = 0;
    }

    public float getSlider()
    {
        return slider.value;
    }
}
