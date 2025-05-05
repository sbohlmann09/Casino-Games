using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public static SliderValue Instance; // Singleton instance for persistence

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    public int sliderValue; // Value to persist across scenes

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the slider with the persisted value
        _slider.value = sliderValue;

        // Update the slider text and persist the value when the slider changes
        _slider.onValueChanged.AddListener((v) => {
            sliderValue = (int)v;
            _sliderText.text = v.ToString("0");
        });
    }
}
