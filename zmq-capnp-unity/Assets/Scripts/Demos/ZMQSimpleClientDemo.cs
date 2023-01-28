using UnityEngine;
using NetMQ;
using NetMQ.Sockets;
using System.Collections.Generic;
using AsyncIO;
using UnityEngine.UI;

public class ZMQSimpleClientDemo : MonoBehaviour
{
    public RawImage image;
    
    private Texture2D tex;
    private SubscriberSocket subscriber;

    private void Start()
    {
        tex = new Texture2D(2, 2, TextureFormat.RGB24, false);
        image.texture = tex;

        ForceDotNet.Force();

        subscriber = new SubscriberSocket("tcp://localhost:5555");
        subscriber.Subscribe("myTopicNameGoesHere");
    }

    private void LateUpdate() // could also be in update
    {
        List<byte[]> msg = null;
        // batch receive up to 100 messages in case publisher is faster than this client's rate
        // this empties the zmq incoming message queue quickly so that we always have the latest message
        for (var count = 0; count < 100; count++)
        {
            if (!subscriber.TryReceiveMultipartBytes(ref msg)) break;
        }

        if (msg != null)
        {
            byte[] topic = msg[0]; // first frame is the topic
            byte[] contents = msg[1]; // second frame is the contents
            
            tex.LoadImage(contents);
        }
    }

    private void OnDestroy()
    {
        subscriber?.Dispose();
        NetMQConfig.Cleanup(false);
    }
}