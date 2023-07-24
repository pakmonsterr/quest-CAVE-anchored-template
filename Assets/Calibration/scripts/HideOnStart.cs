using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    void Start()
    {
        // hides main scene before calibration if not yet already calibrated
        gameObject.SetActive(false);
    }
}
