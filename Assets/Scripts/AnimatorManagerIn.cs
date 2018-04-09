using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorManagerIn : MonoBehaviour
{
    private Animator trayAnimator;
    private Animator pointerAnimator;
    private Animator diskAnimator;
    private GameObject buttonText;


    // Use this for initialization
    void Start()
    {
        pointerAnimator = GameObject.Find("Pointer").GetComponent<Animator>();
        trayAnimator = GameObject.Find("Tray").GetComponent<Animator>();
        diskAnimator = GameObject.Find("DvdDisk2").GetComponent<Animator>();
        buttonText = GameObject.Find("LaunchAnimationInButton");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextAnimation()

    {
        buttonText.GetComponentInChildren<Text>().text = "Next Step";
        pointerAnimator.Play("ArrowOut");

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ArrowOut"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            trayAnimator.Play("TrayOut");
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayOut"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            trayAnimator.Play("OnPlace");
            diskAnimator.Play("DiskIn");
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("OnPlace"))
        {
            trayAnimator.Play("OnPlace");
            pointerAnimator.Play("Arrow");
            diskAnimator.Play("DiskOnPlace");
        }

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Arrow"))
        {
            trayAnimator.Play("TrayIn");
            pointerAnimator.Rebind();
            
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayIn"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            buttonText.GetComponentInChildren<Text>().text = "Insert a disc";
        }













    }



}
