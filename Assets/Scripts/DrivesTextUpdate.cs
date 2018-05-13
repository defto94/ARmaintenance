using PerformanceMonitor.Lib;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DrivesTextUpdate : MonoBehaviour, IPerformanceMonitorDataHandler
{
    public bool animationStarted;
    public GameObject CDmodel;
    public GameObject ButtonAnimationIn;
    public GameObject ButtonAnimationOut;
    public GameObject animatedCDmodel;
    public GameObject counterDiskIn;
    public GameObject counterDiskOut;

    private bool isDiskInside;

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
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDiskInside)
        {
            ButtonAnimationIn.SetActive(false);
            ButtonAnimationOut.SetActive(true);
            counterDiskIn.SetActive(false);
            counterDiskOut.SetActive(true);
        }
        else if (!isDiskInside)
        {

            ButtonAnimationIn.SetActive(true);
            ButtonAnimationOut.SetActive(false);
            counterDiskIn.SetActive(true);
            counterDiskOut.SetActive(false);
        }

        CDmodel.SetActive(isDiskInside && !animationStarted);


    }
}