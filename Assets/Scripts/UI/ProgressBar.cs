using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private void Start()
    {
        SetValue(1,1);
    }

    public void SetValue(float currentValue, float maxValue)
    {
        _bar.fillAmount = currentValue / maxValue;
    }
}
