using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.action
{
    public class ActionExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("start time:"+Time.time);
            ActionKit.Delay(1.0f, () =>
            {
                Debug.Log("end time:" + Time.time);
            }).Start(this);
        }

        
    }
}