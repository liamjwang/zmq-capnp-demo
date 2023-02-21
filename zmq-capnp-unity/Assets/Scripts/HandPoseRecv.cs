using System;
using System.Globalization;
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
        connect.Subscribe("hand_pose/", OnHandPoseRecv);
        // connect.Subscribe<CapnpGen.HandPose>("hand_pose/", OnHandPoseRecv);


        // instantiate finger objects
        for (int i = 0; i < 5; i++)
        {
            GameObject target = Instantiate(exactPrefab, transform);
            target.name = "finger" + i;
            
            // By using a smooth follow script the motion looks smoother at the cost of extra latency
            GameObject f = Instantiate(smoothPrefab, transform);
            f.name = "fingerFollower" + i;
            SmoothFollowOther smoothFollowOther = f.AddComponent<SmoothFollowOther>();
            smoothFollowOther.translateSmoothTime = 0.1f; // smoothness
            smoothFollowOther.other = target.transform;
        }
    }

    private void OnHandPoseRecv(byte[] handPose)
    {
        var str = System.Text.Encoding.Default.GetString(handPose);
        // print the string
        
        string[] words = str.Split(",");
        
        float[] numbers = new float[words.Length];

        int j = 0;
        foreach (var word in words)
        {
            var num = float.Parse(word, CultureInfo.InvariantCulture);
            numbers[j] = num;
            
            j++;

        }
        
        // print numbers
        foreach (var num in numbers)
        {
            Debug.Log(num);
        }
            // update finger positions
        for (int i = 0; i < 5; i++)
        {
            GameObject f = transform.Find("finger" + i).gameObject;
            f.transform.localPosition = new Vector3(numbers[i * 3], numbers[i * 3 + 1], numbers[i * 3 + 2]);
        }
        
    }
}