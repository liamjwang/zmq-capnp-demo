using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class SnapToTransform : MonoBehaviour
{
    
    public Transform target;
    public Transform rotatable;
    public ObjectManipulator manipulator;

    private bool grabbed;
    // Start is called before the first frame update
    void Start()
    {
        manipulator.OnManipulationStarted.AddListener(OnManipulationStarted);
        manipulator.OnManipulationEnded.AddListener(OnManipulationEnded);
    }

    private void OnManipulationEnded(ManipulationEventData arg0)
    {
        grabbed = false;
    }

    private void OnManipulationStarted(ManipulationEventData arg0)
    {
        grabbed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            rotatable.transform.rotation = Quaternion.LookRotation(transform.position - rotatable.transform.position);
        }
        else
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
    
    public void Snap()
    {

    }
}
