using System;
using System.Collections;
using System.Collections.Generic;
using PerformanceMonitor.Lib;
using UnityEngine;

public class ChangePicture : MonoBehaviour
{
    private PerformanceMonitorNetworkClient pm;
    //bool isDiskInside = false;

    public GameObject green;
    public GameObject red;

    public GameObject labelCPU;
    public GameObject labelMemory;
    public GameObject labelDrives;


    // Use this for initialization
    void Start () {
        pm = GameObject.Find("PerformanceMonitor").GetComponent<PerformanceMonitorNetworkClient>();
    }

  


    // Update is called once per frame
    void Update () {

        if (pm.IsOnline)
        {
            green.SetActive(true);
            red.SetActive(false);

            labelCPU.SetActive(true);
            labelDrives.SetActive(true);
            labelMemory.SetActive(true);

            /*
            if(isDiskInside)
            {
                buttonIn.SetActive(false);
            } else
            {
                buttonIn.SetActive(true);
            } */
        }
        else
        {
            red.SetActive(true);
            green.SetActive(false);

            labelCPU.SetActive(false);
            labelDrives.SetActive(false);
            labelMemory.SetActive(false);

        }
    }


}
