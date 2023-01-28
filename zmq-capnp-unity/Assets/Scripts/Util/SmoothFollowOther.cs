using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowOther : MonoBehaviour
{

    public Transform other;
    
    private Vector3 velocity = Vector3.zero;
    private float currVel = 0;
    public float translateSmoothTime = 0.3F;
    public float rotateSmoothTime = 0.3F;
    public bool followScale = true;
    public bool smoothingEnabled = true;
    public float maxDistance = 0.04f;
    public bool local = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 otherPosition = !local ? other.position : other.localPosition;
        Quaternion otherRotation = !local ? other.rotation : other.localRotation;
        if (!smoothingEnabled)
        {
            if (!local)
            {
                transform.position = otherPosition;
                transform.rotation = otherRotation;
            }
            else
            {
                transform.localPosition = other.localPosition;
                transform.localRotation = other.localRotation;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, otherPosition) > maxDistance)
            {
                if (!local)
                {
                    transform.position = otherPosition;
                    transform.rotation = otherRotation;
                }
                else
                {
                    transform.localPosition = other.localPosition;
                    transform.localRotation = other.localRotation;
                }
            }
            Transform myTransform = transform;
            Vector3 currentPosition = Vector3.SmoothDamp(myTransform.position, otherPosition, ref velocity, translateSmoothTime);
            if (!local)
            {
                myTransform.position = currentPosition;
            } else
            {
                myTransform.localPosition = currentPosition;
            }
            Quaternion transformRotation = myTransform.rotation;
            float delta = Quaternion.Angle(transformRotation, otherRotation);
            if (delta > 0f)
            {
                float t = Mathf.SmoothDampAngle(delta, 0.0f, ref currVel, rotateSmoothTime);
                t = 1.0f - (t / delta);
                Quaternion currentRotation = Quaternion.Slerp(transformRotation, otherRotation, t);
                if (!local)
                {
                    myTransform.rotation = currentRotation;
                } else
                {
                    myTransform.localRotation = currentRotation;
                }
            }

            if (followScale)
                myTransform.localScale = other.localScale;
        }
    }
}
