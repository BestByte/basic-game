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

            // 通过 AssetBundleName 和 资源名搜索并加载资源（更精确）
            prefab = resLoader.LoadSync<GameObject>("assetobj_prefab", "AssetObj");
            gameObj=Instantiate(prefab);
            gameObj.name = " 通过 AssetBundleName 和 资源名搜索并加载资源（更精确）";


		}

		// Update is called once per frame
		void Update()
    {
					
    }
		private void OnDestroy()
		{
			// 释放所有本脚本加载过的资源
			// 释放只是释放资源的引用
			// 当资源的引用数量为 0 时，会进行真正的资源卸载操作
			resLoader.Recycle2Cache();
			resLoader = null;
		}
	}
}