using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorManagerIn : MonoBehaviour
{
    private Animator trayAnimator;
    private Animator pointerAnimator;
    private Animator diskAnimator;
    private Text counterText;

    // Use this for initialization
    void Start()
    {
        pointerAnimator = GameObject.Find("Pointer").GetComponent<Animator>();
        trayAnimator = GameObject.Find("Tray").GetComponent<Animator>();
        diskAnimator = GameObject.Find("DvdDisk2").GetComponent<Animator>();
        counterText = GameObject.Find("CountAnimationTextIn").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextAnimation()

    {
        pointerAnimator.Play("ArrowOut");
        counterText.text = "1/6";

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ArrowOut"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            trayAnimator.Play("TrayOut");
            counterText.text = "2/6";
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayOut"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            trayAnimator.Play("OnPlace");
            diskAnimator.Play("DiskIn");
            counterText.text = "3/6";
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("OnPlace"))
        {
            trayAnimator.Play("OnPlace");
            pointerAnimator.Play("Arrow");
            diskAnimator.Play("DiskOnPlace");
            counterText.text = "4/6";
        }

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Arrow"))
        {
            trayAnimator.Play("TrayIn");
            pointerAnimator.Rebind();
            counterText.text = "5/6";
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayIn"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            counterText.text = "6/6";
        }













    }



}
