using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.res { 
public class ReskitExample : MonoBehaviour
{

        private ResLoader resLoader = ResLoader.Allocate();
    // Start is called before the first frame update
    void Start()
    {
			// 项目启动只调用一次即可
			ResKit.Init();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}