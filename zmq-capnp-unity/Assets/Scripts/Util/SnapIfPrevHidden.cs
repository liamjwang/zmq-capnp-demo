using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class SnapIfPrevHidden : MonoBehaviour
{
    private SolverHandler solver;
    private HandConstraintPalmUp handConstraintPalmUp;

    public GameObject menuContent;

    // Start is called before the first frame update
    void Start()
    {
        solver = GetComponent<SolverHandler>();
        handConstraintPalmUp = GetComponent<HandConstraintPalmUp>();
    }

    public void HandDetected()
    {
        if (!menuContent.activeSelf)
        {
            handConstraintPalmUp.Smoothing = false;
            handConstraintPalmUp.SolverUpdate();
            handConstraintPalmUp.UpdateWorkingToGoal();
            handConstraintPalmUp.Smoothing = true;
            menuContent.SetActive(true);
        }
    }
}
