using System;
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using Microsoft.MixedReality.QR;
using UnityEngine.Serialization;

namespace QRTracking
{
    public class QRCodesDataEvents : Singleton<QRCodesDataEvents>
    {
        public struct QRActionData
        {
            public enum Type
            {
                Added,
                Updated,
                Removed
            };
            public Type type;
            public Microsoft.MixedReality.QR.QRCode qrCode;

            public QRActionData(Type type, Microsoft.MixedReality.QR.QRCode qRCode) : this()
            {
                this.type = type;
                qrCode = qRCode;
            }
        }

        private readonly Dictionary<string, List<Action<QRActionData>>> qrCodesActions = new();

        private readonly Queue<QRActionData> pendingActions = new();

        // Use this for initialization
        void Start()
        {
            QRCodesManager.Instance.QRCodesTrackingStateChanged += Instance_QRCodesTrackingStateChanged;
            QRCodesManager.Instance.QRCodeAdded += Instance_QRCodeAdded;
            QRCodesManager.Instance.QRCodeUpdated += Instance_QRCodeUpdated;
            QRCodesManager.Instance.QRCodeRemoved += Instance_QRCodeRemoved;
        }
        private void Instance_QRCodesTrackingStateChanged(object sender, bool status)
        {
        }

        private void Instance_QRCodeAdded(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
        {
            Debug.Log("QRCodesVisualizer Instance_QRCodeAdded");

            lock (pendingActions)
            {
                pendingActions.Enqueue(new QRActionData(QRActionData.Type.Added, e.Data));
            }
        }

        private void Instance_QRCodeUpdated(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
        {
            Debug.Log("QRCodesVisualizer Instance_QRCodeUpdated");

            lock (pendingActions)
            {
                pendingActions.Enqueue(new QRActionData(QRActionData.Type.Updated, e.Data));
            }
        }

        private void Instance_QRCodeRemoved(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
        {
            Debug.Log("QRCodesVisualizer Instance_QRCodeRemoved");

            lock (pendingActions)
            {
                pendingActions.Enqueue(new QRActionData(QRActionData.Type.Removed, e.Data));
            }
        }

        private void HandleEvents()
        {
            lock (pendingActions)
            {
                while (pendingActions.Count > 0)
                {
                    var action = pendingActions.Dequeue();
                    string qrCodeData = action.qrCode.Data;
                    if (qrCodesActions.ContainsKey(qrCodeData))
                    {
                        foreach (var actionHandler in qrCodesActions[qrCodeData])
                        {
                            actionHandler(action);
                        }
                    }
                }
            }
        }

        public void Subscribe(string data, Action<QRActionData> action)
        {
            if (!qrCodesActions.ContainsKey(data))
            {
                qrCodesActions.Add(data, new List<Action<QRActionData>>());
            }
            
            qrCodesActions[data].Add(action);
        }


        // Update is called once per frame
        void Update()
        {
            HandleEvents();
        }
    }

}