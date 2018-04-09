using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorManagerOut : MonoBehaviour {

    private Animator modelAnimator;
    private Animator trayAnimator;
    private Animator pointerAnimator;
    private Animator diskAnimator;
    private GameObject buttonText;

    void Start () {
        pointerAnimator = GameObject.Find("Pointer").GetComponent<Animator>();
        trayAnimator = GameObject.Find("Tray").GetComponent<Animator>();
        diskAnimator = GameObject.Find("DvdDisk2").GetComponent<Animator>();
        buttonText = GameObject.Find("LaunchAnimationOutButton");
    }

    public void NextAnimation()
    {
        pointerAnimator.Play("ArrowOut");
        diskAnimator.Play("DiskOnPlace");
        buttonText.GetComponentInChildren<Text>().text = "Next Step";

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ArrowOut"))
        {
            pointerAnimator.Rebind();
            trayAnimator.Play("TrayOut");
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayOut"))
        {
            trayAnimator.Rebind();
            pointerAnimator.Rebind();
            trayAnimator.Play("OnPlace");
            diskAnimator.Play("DiskOut");
        }

        if (diskAnimator.GetCurrentAnimatorStateInfo(0).IsName("DiskOut"))
        {
            diskAnimator.Rebind();
            pointerAnimator.Play("Arrow");
        }

        if (pointerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Arrow"))
        {
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            trayAnimator.Play("TrayIn");
        }

        if (trayAnimator.GetCurrentAnimatorStateInfo(0).IsName("TrayIn"))
        {
            pointerAnimator.Rebind();
            diskAnimator.Rebind();
            trayAnimator.Rebind();
            buttonText.GetComponentInChildren<Text>().text = "Remove a disc";
        }
    }
}
