using PerformanceMonitor.Lib;
using System;
using UnityEngine.Events;

/// <summary>
/// Unity event that passess PerformanceData object as an argument.
/// </summary>
[Serializable]
public class PerformanceDataUpdateEvent : UnityEvent<PerformanceData>
{
}