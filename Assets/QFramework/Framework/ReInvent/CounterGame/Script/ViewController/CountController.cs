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
          

			// 监听输入
			mBtnAdd.onClick.AddListener(() =>
			{
				// 交互逻辑
				this.SendCommand<IncreaseCountCommand>();
			});

			mBtnSub.onClick.AddListener(() =>
			{
				// 交互逻辑
				this.SendCommand(new DecreaseCountCommand(/* 这里可以传参（如果有） */));
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