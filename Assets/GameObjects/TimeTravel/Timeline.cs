using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Timeline : MonoBehaviour
{
    ArrayList timeline;
    int frameSize;  //The size of the serial for a full frame, assembled during awake

    //Transform Serializer
    SerializeTransform transformSerializer;

    private void Awake()
    {
        timeline = new ArrayList();
        //Transform is always attached
        transformSerializer = new SerializeTransform();
        frameSize += transformSerializer.SerialSize;

        //Components that aren't always attached
    }

    private void FixedUpdate()
    {
        Serialize();
    }
    private void Serialize()
    {
        //Transform is always attached
        timeline.AddRange(transformSerializer.SerializeComponent(transform));
    }

    private void DeserializeAtFrame(int frame)
    {
        //Get the byte offset where the frame's data should start
        int offset = frame * frameSize;

        //Update components with new information


        //Clear timeline information after this event
    }
}
