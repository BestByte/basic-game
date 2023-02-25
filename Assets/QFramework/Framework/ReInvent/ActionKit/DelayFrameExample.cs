using System.Collections;
using System.Collections.Generic;

using QFramework;

using UnityEngine;
namespace QFramework.action {
    public class DelayFrameExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Delay Frame Start FrameCount:" + Time.frameCount);
            ActionKit.DelayFrame(1, () =>
            {
                Debug.Log("delya fram finish :" + Time.frameCount);
            }).Start(this);

            ActionKit.Sequence()
                .DelayFrame(10)
                .Callback(() => Debug.Log("sequence delay framecount£º" + Time.frameCount))
                .Start(this);

            ActionKit.NextFrame(() => { }).Start(this);
    
    }
    }
    
}
