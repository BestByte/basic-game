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

            // ͨ�� AssetBundleName �� ��Դ��������������Դ������ȷ��
            prefab = resLoader.LoadSync<GameObject>("assetobj_prefab", "AssetObj");
            gameObj=Instantiate(prefab);
            gameObj.name = " ͨ�� AssetBundleName �� ��Դ��������������Դ������ȷ��";


		}

		// Update is called once per frame
		void Update()
    {
					
    }
		private void OnDestroy()
		{
			// �ͷ����б��ű����ع�����Դ
			// �ͷ�ֻ���ͷ���Դ������
			// ����Դ����������Ϊ 0 ʱ���������������Դж�ز���
			resLoader.Recycle2Cache();
			resLoader = null;
		}
	}
}