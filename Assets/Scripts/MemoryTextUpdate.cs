using PerformanceMonitor.Lib;
using UnityEngine;
using UnityEngine.UI;

public class MemoryTextUpdate : MonoBehaviour, IPerformanceMonitorDataHandler
{
    public void UpdatePerformanceDisplay(PerformanceData data)
    {
        GetComponent<Text>().text = data.MemoryAvailable.ToString();
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