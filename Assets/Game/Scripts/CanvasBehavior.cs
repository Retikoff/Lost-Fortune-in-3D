using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBehavior : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text minSliderValue;
    [SerializeField] private TMP_Text maxSliderValue;
    [SerializeField] private TMP_Text currentSliderValue;

    void Start()
    {
        slider.onValueChanged.AddListener(delegate { SliderUpdate(); });
        SetSliderBounds(slider.minValue, slider.maxValue);
    }

    public void SubmitInput()
    {
        gameObject.SetActive(false);
        gameManager.GenerateScene(input.text, slider.value, dropdown.value);
        Debug.Log("Пользователь ввел: \n" + "Name:" + input.text + "\nNumber: " + slider.value + "\nObject: " + dropdown.value);
    }

    public void SliderUpdate()
    {
        currentSliderValue.text = slider.value.ToString();
    }

    private void SetSliderBounds(float up, float down) // rename
    {
        minSliderValue.text = up.ToString();
        maxSliderValue.text = down.ToString();
    }
}
