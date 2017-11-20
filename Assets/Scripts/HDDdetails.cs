using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HDDdetails : MonoBehaviour {

    public Text detailsText;
    public string detailsString = "Rozmiar dysku:  931,51  GB";

    public GameObject HDD;

    // Use this for initialization
    void Start () {
        detailsText.text = detailsString;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
