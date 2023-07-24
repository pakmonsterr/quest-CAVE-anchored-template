using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class PalmMenu : MonoBehaviour
{
    // button stuff
    public GameObject confirm_btn, redo_btn;
    public bool calibrated = false;
    
    // pose stuff
    [SerializeField]
    private ActiveStateSelector _pose;


    protected virtual void Start()
    {
        // bind functions to detected poses 
        _pose.WhenSelected += () => palmUp();
        _pose.WhenUnselected += () => palmDown();
        confirm_btn.SetActive(false);
        redo_btn.SetActive(false);
    }
    
    private void palmUp()
    {
        if (calibrated)
        {
            redo_btn.SetActive(true);
        }
        else
        {
            confirm_btn.SetActive(true);
        }
    }

    private void palmDown()
    {
        redo_btn.SetActive(false);
        confirm_btn.SetActive(false);
    }
}
