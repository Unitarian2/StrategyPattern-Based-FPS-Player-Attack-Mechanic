using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBasicDataUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;

    private void OnEnable()
    {
        PlayerStats.OnHealthChanged += PlayerStats_OnHealthChanged;
        PlayerStats.OnManaChanged += PlayerStats_OnManaChanged;
    }

    private void OnDisable()
    {
        PlayerStats.OnHealthChanged -= PlayerStats_OnHealthChanged;
        PlayerStats.OnManaChanged -= PlayerStats_OnManaChanged;
    }

    public void Setup()
    {
        healthSlider.value = 1; manaSlider.value = 1;
        SliderAnim();
    }

    private void SliderAnim()
    {
        Debug.Log("Slider Anim");
    }

    private void PlayerStats_OnHealthChanged(float currentHealthAmount, float maxHealth)
    {
        healthSlider.value = currentHealthAmount / maxHealth;
    }

    private void PlayerStats_OnManaChanged(float currentManaAmount, float maxMana)
    {
        manaSlider.value = currentManaAmount / maxMana;
    }
}
