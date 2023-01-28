using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SmoothFollowOther))]
public class SmoothFollowSwitcher : MonoBehaviour
{
    
    public Transform[] targets;
    
    public int currentTarget { get; set; }
    
    private SmoothFollowOther smoothFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        smoothFollow = GetComponent<SmoothFollowOther>();
    }

    // Update is called once per frame
    void Update()
    {
        smoothFollow.other = targets[currentTarget];
    }
}
