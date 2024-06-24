using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomaliesFixed : MonoBehaviour
{
    [SerializeField] public int FixedAnomalies = 0;
    [SerializeField] private Text FixedAnomalyCount;
 
    private void Update()
    {
        FixedAnomalyCount.text = "TOTAL ANOMALIES FIXED: " + FixedAnomalies;
    }

    public void AddOne()
    {
        FixedAnomalies++;
    }
}