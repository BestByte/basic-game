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
			// ��Ŀ����ֻ����һ�μ���
			ResKit.Init();
			// ͨ����Դ�� + ����������������Դ�������㣩
			var prefab = resLoader.LoadSync<GameObject>("AssetObj");
            var gameObj=Instantiate(prefab);
            gameObj.name = "����ͨ��ʹ��assetname ���صĶ���";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}