using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICurrencyFake : MonoBehaviour
{
    public Text softCurrencyText;
    public Text hardCurrencyText;
    public Text softCurrencyFeedbackText;
    public Text hardCurrencyFeedbackText;

    private int softCurrency = 0;
    private int hardCurrency = 0;

    private void Start()
    {
        UpdateCurrencyDisplay();
    }

    public void BuySoftCurrency(int amount)
    {
        softCurrency += amount;
        UpdateCurrencyDisplay();
    }

    public void BuyHardCurrency(int amount)
    {
        hardCurrency += amount;
        UpdateCurrencyDisplay();
    }

    public void FakeBuy(int price)
    {
        if (softCurrency >= price)
        {
            softCurrency -= price;
            SetSoftCurrencyFeedback("Purchase successful!");
        }
        else
        {
            SetSoftCurrencyFeedback("Not enough catnip to buy!");
        }

        UpdateCurrencyDisplay();
    }

    public void FakeBuyHardCurrency(int price)
    {
        if (hardCurrency >= price)
        {
            hardCurrency -= price;
            SetHardCurrencyFeedback("Mouse coin purchase successful!");
        }
        else
        {
            SetHardCurrencyFeedback("Not enough Mouse Coin to buy!");
        }

        UpdateCurrencyDisplay();
    }

    private void UpdateCurrencyDisplay()
    {
        softCurrencyText.text = "Soft Currency: " + softCurrency.ToString();
        hardCurrencyText.text = "Hard Currency: " + hardCurrency.ToString();
    }

    private void SetSoftCurrencyFeedback(string message)
    {
        softCurrencyFeedbackText.text = message;
    }

    private void SetHardCurrencyFeedback(string message)
    {
        hardCurrencyFeedbackText.text = message;
    }
}