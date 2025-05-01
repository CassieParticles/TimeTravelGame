using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class ISerializeComponent
{
    //Get size of the serial provided
    public abstract int SerialSize { get; }

    //Generate serial for component provided
    public abstract byte[] SerializeComponent(Component component);

    //Deserialize data from serial into provided component
    public abstract void DeserializeComponent(byte[] serial, Component component);
}

public class SerializeTransform:ISerializeComponent
{
    //Position, Rotation, Scale
    //3 comps * 3 floats * 4 bytes = 36 bytes
    public override int SerialSize { get { return 36; } }

    public override byte[] SerializeComponent(Component component)
    {        
        byte[] serial = new byte[36];

        Transform transform = (Transform)component;

        //Create float buffer to convert into bytes
        float[] componentData = new float[9] 
        {
            transform.position.x,transform.position.y,transform.position.z,
            transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z,
            transform.localScale.x,transform.localScale.y,transform.localScale.z
        };

        //Copy byte data to serial (preserves bytes)
        Buffer.BlockCopy(componentData, 0, serial, 0, SerialSize);
        
        return serial;
    }

    public override void DeserializeComponent(byte[] serial, Component component)
    {
        //Create float buffer to take in serial
        float[] componentData = new float[9];

        //Copy data
        Buffer.BlockCopy(serial,0,componentData,0, SerialSize);

        //Change transform to use data
        Transform transform = (Transform)component;

        transform.position = new Vector3(componentData[0],componentData[1],componentData[2]);
        transform.rotation = Quaternion.Euler(componentData[3], componentData[4], componentData[5]);
        transform.localScale = new Vector3(componentData[6],componentData[7],componentData[8]);
    }
}