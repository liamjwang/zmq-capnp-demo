using System;
using System.Collections;
using System.Collections.Generic;
using QRTracking;
using UnityEngine;
using Util;

public class QRFollower : MonoBehaviour
{
    public string data;
    [HideInInspector]
    public long lastUpdated;

    private Matrix4x4 lastPose;
    public float UpdateDistThresh = 0.001f;
    public float UpdateAngleThresh = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        QRCodesDataEvents.Instance.Subscribe(data, OnDataAction);
    }

    private void OnDataAction(QRCodesDataEvents.QRActionData obj)
    {
        Microsoft.MixedReality.QR.QRCode qrCode = obj.qrCode;
        SpatialGraphCoordinateSystem spatialGraphCoordinateSystem = gameObject.GetOrAddComponent<QRTracking.SpatialGraphCoordinateSystem>();
        spatialGraphCoordinateSystem.Id = qrCode.SpatialGraphNodeId;
        lastUpdated = Time.frameCount;
        Debug.Log("QRFollower Updated: " + qrCode.Id + " " + qrCode.Data + " " + data);
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 pose = transform.GetMatrix();
        if (Vector3.Magnitude(pose.GetPosition() - lastPose.GetPosition()) > UpdateDistThresh || Quaternion.Angle(pose.GetRotation(), lastPose.GetRotation()) > UpdateAngleThresh)
        {
            lastPose = pose;
            lastUpdated = Time.frameCount;
        }
    }
}
