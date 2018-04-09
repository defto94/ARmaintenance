using PerformanceMonitor.Lib;

/// <summary>
/// Handler declaration for the PerformanceDataUpdateEvent
/// </summary>
public interface IPerformanceMonitorDataHandler
{
    void UpdatePerformanceDisplay(PerformanceData data);
}