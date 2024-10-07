using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReflipCounter : MonoBehaviour
{
    public int flipsRemaining;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        updateFlipCounter();
    }

    public void updateFlipCounter()
    {
        text.text = "Reflips Remaining: " + flipsRemaining;
    }
}
