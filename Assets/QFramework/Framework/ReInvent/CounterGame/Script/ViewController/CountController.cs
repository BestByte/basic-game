using QFramework;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountGame
{
    public class CountController : MonoBehaviour,IController
    {
		// View
		private Button mBtnAdd;
		private Button mBtnSub;
		private Text mCountText;


		private ICountModel mCountModel;
		public IArchitecture GetArchitecture()
		{
            return CountGame.Interface;
		}


		// Start is called before the first frame update
		void Start()
        {
			mCountModel=this.GetComponent<ICountModel>();

			mCountText = this.transform.Find("CountText ").GetComponent<Text>();
			mBtnAdd = this.transform.Find("ButtonAdd").GetComponent<Button>();
            mBtnSub=this.transform.Find("ButtonSub").GetComponent <Button>();
          

			// ��������
			mBtnAdd.onClick.AddListener(() =>
			{
				// �����߼�
				this.SendCommand<IncreaseCountCommand>();
			});

			mBtnSub.onClick.AddListener(() =>
			{
				// �����߼�
				this.SendCommand(new DecreaseCountCommand(/* ������Դ��Σ�����У� */));
			});

			mCountModel.Count.RegisterWithInitValue(newCount =>
			{
				UpdateView();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

		private void UpdateView()
		{
			mCountText.text=mCountModel.Count.ToString();
		}

		
    }

}