using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Health HealthComponent;
    public Slider UIElement;

    void Awake()
    {
        HealthComponent.OnHealthChange.AddListener(UpdateUI);
    }

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        UIElement.value = (float)HealthComponent.Current / (float)HealthComponent.MaxHealth;
    }

}
