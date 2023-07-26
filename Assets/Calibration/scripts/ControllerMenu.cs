using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;

public class ControllerMenu : MonoBehaviour
{
    public bool calibrated;
    public GameObject control_menu, place_marker;
    public TMP_Text calib_option;

    public AnchorManager Anchor_manager;
    
    void Start()
    {
        // see if anchor was stored from last session
        calibrated = Anchor_manager.checkUuid() ? true : false;
    }

    void Update()
    {
        bool hand_tracking = OVRPlugin.GetHandTrackingEnabled();
        
        control_menu.SetActive(hand_tracking ? false : true);
        
        calib_option.text = calibrated ? "(A) Redo" : "(A) Confirm";
        
        // get button input, run anchor manager function based on input
        if (OVRInput.GetDown(OVRInput.RawButton.A) && control_menu.activeSelf && !hand_tracking)
        {
            if (!calibrated)
            {
                calibrated = true;
                Anchor_manager.onPressConfirm();
            }
            else
            {
                calibrated = false;
                Anchor_manager.onPressRedo();
            }
        }

        // hide menu & deactivate some calibration 
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            control_menu.SetActive(!control_menu.activeSelf);
            place_marker.SetActive(!place_marker.activeSelf);
        }
    }
}
