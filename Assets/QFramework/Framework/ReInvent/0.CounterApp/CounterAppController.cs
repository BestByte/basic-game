using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Reinvent { 
public class CounterAppController : MonoBehaviour
{
        #region view

        private Button mBtnAdd;
        private Button mBtnSub;
        private Text mCounterTxt;

        #endregion

        #region model
        private int mCount=0;
		#endregion
		// Start is called before the first frame update
		void Start()
    {
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub=transform.Find("BtnSub").GetComponent<Button>();
            mCounterTxt=transform.Find("CountTxt").GetComponent<Text>();

			#region controller
			mBtnAdd.onClick.AddListener(() =>
            {
                mCount++;
                UpdateView();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                mCount--;
                UpdateView();
            });
			#endregion
		}

		private void UpdateView()
		{
			mCounterTxt.text = mCount.ToString();
		}

		
}
}

namespace QFramework.MVC
{
    using QFramework;

	#region 1. 定义一个 Model 对象
	public class CounterAppModel:AbstractModel
    {
        public int Count;
		protected override void OnInit()
		{
			Count= 0;
		}

	}
	#endregion

	#region  2.定义一个架构（提供 MVC、分层、模块管理等）
	public class CounterApp : Architecture<CounterApp>
	{
		protected override void Init()
		{
			this.RegisterModel(new CounterAppModel());
		}
	}
	#endregion

	#region Controller
	public class CounterAppController : MonoBehaviour, IController
	{
		public IArchitecture GetArchitecture()
		{
			throw new NotImplementedException();
		}
	}
	#endregion
}