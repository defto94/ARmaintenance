using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HDDdetails : MonoBehaviour {

    public TextMesh detailsText;
    public string detailsString = "Pojemność dysku HDD: 931,51 GB";

    public GameObject HDD;

    // Use this for initialization
    void Start () {
        detailsText.text = detailsString;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
