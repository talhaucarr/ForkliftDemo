using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelUI : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private Image fuelImage;

    private FuelModule _fuelModule;

    private void Start()
    {
        _fuelModule = GetComponent<FuelModule>();
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        fuelImage.fillAmount = _fuelModule.CurFuel /_fuelModule.MaxFuel;
        fuelText.text = "Fuel:" + _fuelModule.CurFuel;
    }

}
