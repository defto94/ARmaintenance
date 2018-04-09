using System.Collections;
using System.Collections.Generic;
using PerformanceMonitor.Lib;
using UnityEngine;
using UnityEngine.UI;

public class CpuTextUpdate : MonoBehaviour, IPerformanceMonitorDataHandler
{
    public void UpdatePerformanceDisplay(PerformanceData data)
    {
        GetComponent<Text>().text = data.CpuUsage.ToString();
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}