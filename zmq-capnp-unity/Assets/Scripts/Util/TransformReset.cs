using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReset : MonoBehaviour
{
    private Matrix4x4 initialPose;

    // Start is called before the first frame update
    void Start()
    {
        initialPose = transform.GetMatrix();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ResetTransform()
    {
        transform.SetMatrix(initialPose);
    }
}
