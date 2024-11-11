using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusCollect : MonoBehaviour
{
    public TextMeshProUGUI points;
    public int batterys;

    private void Start()
    {
        points = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        points.text = batterys.ToString();
    }

    public void Collect()
    {
        batterys += 1;
    }
    
}
