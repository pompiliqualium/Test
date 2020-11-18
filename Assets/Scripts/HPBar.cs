using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    private Image fillImage;

    private void Awake() {
        fillImage = slider.fillRect.GetComponent<Image>();
    }

    public void SetHealth(float health) {
        slider.value = health;

        SetColor();
    }

    public void SetMaxHP(float health) {
        slider.maxValue = health;
        slider.value =health;

        SetColor();

    }

    public void SetColor() {
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }

}
