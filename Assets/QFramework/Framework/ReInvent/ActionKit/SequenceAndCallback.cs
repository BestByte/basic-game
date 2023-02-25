using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.action { 
public class SequenceAndCallback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("sequence start£º"+Time.time);
            ActionKit.Sequence()
                .Callback(() => Debug.Log("Delay start:" + Time.time)).
                Delay(1.0f)
                .Callback(() => Debug.Log("deblay finish:" + Time.time))
                .Start(this, _ => { Debug.Log("sequence finish£º" + Time.time); });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
}