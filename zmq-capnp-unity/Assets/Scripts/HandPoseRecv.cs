using System;
using System.IO;
using Capnp;
using CapnpGen;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class HandPoseRecv : MonoBehaviour
{
    public GameObject smoothPrefab;
    public GameObject exactPrefab;


    private void Start()
    {
        ZMQConnection connect = ZMQConnection.GetOrCreateInstance();
        connect.Subscribe<CapnpGen.HandPose>("hand_pose/", OnHandPoseRecv);


        // instantiate finger objects
        for (int i = 0; i < 5; i++)
        {
            GameObject target = Instantiate(exactPrefab, transform);
            target.name = "finger" + i;
            
            GameObject f = Instantiate(smoothPrefab, transform);
            f.name = "fingerFollower" + i;
            SmoothFollowOther smoothFollowOther = f.AddComponent<SmoothFollowOther>();
            smoothFollowOther.other = target.transform;
        }
    }

    private void OnHandPoseRecv(CapnpGen.HandPose handPose)
    {
        // update finger positions
        for (int i = 0; i < 5; i++)
        {
            GameObject f = transform.Find("finger" + i).gameObject;
            f.transform.localPosition = new Vector3(handPose.Fingers[i].X, handPose.Fingers[i].Y, handPose.Fingers[i].Z);
        }
    }
}