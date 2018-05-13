using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorManagerOut : MonoBehaviour {

    private Animator modelAnimator;
    private Animator trayAnimator;
    private Animator pointerAnimator;
    private Animator diskAnimator;
    public DrivesTextUpdate drivesUpdate;
    private Text counterText;

    void Start () {
        pointerAnimator = GameObject.Find("Pointer").GetComponent<Animator>();
        trayAnimator = GameObject.Find("Tray").GetComponent<Animator>();
        diskAnimator = GameObject.Find("DvdDisk2").GetComponent<Animator>();
        ///drivesUpdate = GameObject.Find("DrivesText").GetComponent<DrivesTextUpdate>();
        counterText = GameObject.Find("CountAnimationTextOut").GetComponent<Text>();
    }

    public void NextAnimation()
    {
      
        pointerAnimator.Play("ArrowOut");
        diskAnimator.Play("DiskOnPlace");
        drivesUpdate.animationStarted = true;
        counterText.text = "1/6";

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ArrowOut"))
        {
            drivesUpdate.animationStarted = true;
            pointerAnimator.Rebind();
            trayAnimator.Play("TrayOut");
            counterText.text = "2/6";
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayOut"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            trayAnimator.Play("OnPlace");
            diskAnimator.Play("DiskOut");
            counterText.text = "3/6";
        }

        if (diskAnimator.GetCurrentAnimatorStateInfo(0).IsName("DiskOut"))
        {
            diskAnimator.Rebind();
            pointerAnimator.Play("Arrow");
            counterText.text = "4/6";
        }

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Arrow"))
        {
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            trayAnimator.Play("TrayIn");
            counterText.text = "5/6";
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayIn"))
        {
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            trayAnimator.Rebind();
            counterText.text = "6/6";

            drivesUpdate.animationStarted = false;
        }
    }
}
