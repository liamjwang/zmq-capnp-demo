using System;
using System.IO;
using Capnp;
using CapnpGen;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class HandPoseRecv : MonoBehaviour
{
    public GameObject finger;

    private void Start()
    {
        ZMQConnection connect = ZMQConnection.GetOrCreateInstance();
        connect.Subscribe<CapnpGen.HandPose>("hand_pose/", OnHandPoseRecv);

        // instantiate finger objects
        for (int i = 0; i < 5; i++)
        {
            GameObject f = Instantiate(finger, transform);
            f.name = "finger" + i;
        }
    }

    private void OnHandPoseRecv(CapnpGen.HandPose handPose)
    {
        // Debug.Log("Hand pose received!");

        // update finger positions
        for (int i = 0; i < 5; i++)
        {
            GameObject f = transform.Find("finger" + i).gameObject;
            f.transform.localPosition = new Vector3(handPose.Finger[i].X, handPose.Finger[i].Y, handPose.Finger[i].Z);
        }
    }
}