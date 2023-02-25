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
			// 通过资源名 + 类型搜索并加载资源（更方便）
			var prefab = resLoader.LoadSync<GameObject>("AssetObj");
            var gameObj=Instantiate(prefab);
            gameObj.name = "这是通过使用assetname 加载的对象";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}