using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelModule : MonoBehaviour,IFuelModule
{
    [Header("Options")]
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelTankAmount;
    [SerializeField] private float fuelDecreaseAmount;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private Image fuelImage;

    [Header("Monitors")]
    [SerializeField] [ShowOnly] private float curFuel;

    void Start()
    {
        curFuel = maxFuel;
    }

    void Update()
    {
        ControlFuelAmount();
        DecreaseFuel(fuelDecreaseAmount);//motor calistiginda azalmaya basliyor
        UpdateUI();
    }

    private void UpdateUI()
    {
        fuelImage.fillAmount = curFuel / maxFuel;
        fuelText.text = "Fuel:" + curFuel;
    }

    public void DecreaseFuel(float fuelAmount)
    {
        curFuel -= fuelAmount * Time.deltaTime;

        ControlFuelAmount();
    }

    private void ControlFuelAmount()
    {
        if (!IsFuelTankEmpty())
        {
            curFuel = 0;
            Death();
        }
    }

    public void IncreaseFuel(float fuelAmount)
    {
        curFuel = Mathf.Clamp(curFuel + fuelAmount, 0, maxFuel);
    }

    private bool IsFuelTankEmpty()
    {
        return curFuel >= 0 ? true : false;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
