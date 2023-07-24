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
    
    // Start is called before the first frame update
    void Start()
    {
        calibrated = Anchor_manager.checkUuid() ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        calib_option.text = calibrated ? "(A) Redo" : "(A) Confirm";
        
        if (OVRInput.GetDown(OVRInput.RawButton.A) && control_menu.activeSelf)
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

        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            control_menu.SetActive(!control_menu.activeSelf);
            place_marker.SetActive(!place_marker.activeSelf);
        }
    }
}
