using PerformanceMonitor.Lib;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DrivesTextUpdate : MonoBehaviour, IPerformanceMonitorDataHandler
{
    public Button animationButtonIn;
    public Button animationButtonOut;
    //public GameObject DVD;
    GameObject DVD;
    bool isDiskInside = false;
    private PerformanceMonitorNetworkClient pm;


    public void UpdatePerformanceDisplay(PerformanceData data)
    {
        var sb = new StringBuilder();

        foreach (var drive in data.DrivesData)
        {
            sb.AppendLine(drive.ToString());

            if (drive.DriveType == DriveType.CDRom)
            {
                isDiskInside = drive.IsReady;
            }
        }

        GetComponent<Text>().text = sb.ToString();
    }

    // Use this for initialization
    private void Start()
    {
        DVD = GameObject.Find("Tray/DvdDisk2");
        pm = GameObject.Find("PerformanceMonitor").GetComponent<PerformanceMonitorNetworkClient>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!pm.IsOnline)
        {
            animationButtonIn.gameObject.SetActive(false);
            animationButtonOut.gameObject.SetActive(false);
        }
        else if (isDiskInside)
        {
            animationButtonIn.gameObject.SetActive(false);
            animationButtonOut.gameObject.SetActive(true);
            DVD.transform.position = new Vector3(-4.0f, 3.4f, 6.0f); 
        }
        else
        {
            animationButtonOut.gameObject.SetActive(false);
            animationButtonIn.gameObject.SetActive(true);
            DVD.transform.position = new Vector3(-4, 410, 6); 

        }
    }
}