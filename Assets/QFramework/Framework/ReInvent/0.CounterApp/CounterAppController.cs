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
	/// <summary>
	/// Architecture ���ڹ���ģ�飬����˵ Architecture �ṩһ���׼ܹ��Ľ����������ģ�������ṩ MVC ֻ���书�ܵ�һС���֡�
	/// </summary>
	#region 1. ����һ�� Model ����
	public class CounterAppModel:AbstractModel
    {
        public int Count;
		protected override void OnInit()
		{
			Count= 0;
		}

	}
	#endregion

	#region  2.����һ���ܹ����ṩ MVC���ֲ㡢ģ�����ȣ�
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
		// View
		private Button mBtnAdd;
		private Button mBtnSub;
		private Text mCountText;
		// 4. Model
		private CounterAppModel mModel;
		/// <summary>
		/// // 3.ָ���ܹ�
		/// </summary>
		/// <returns></returns>
		public IArchitecture GetArchitecture()
		{
			return CounterApp.Interface;
		}

		void Start()
		{
			// 5. ��ȡģ��
			mModel = this.GetModel<CounterAppModel>();

			mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
			mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
			mCountText = transform.Find("CountTxt").GetComponent<Text>();

			#region controller
			mBtnAdd.onClick.AddListener(() =>
			{
				mModel.Count++;
				UpdateView();
			});

			mBtnSub.onClick.AddListener(() =>
			{
				mModel.Count--;
				UpdateView();
			});
			#endregion
		}

		private void UpdateView()
		{
			mCountText.text = mModel.Count.ToString();
		}

		private void OnDestroy()
		{
			mModel=null;
		}
	}
	#endregion
}