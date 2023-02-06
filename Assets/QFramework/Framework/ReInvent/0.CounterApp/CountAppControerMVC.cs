using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MVC
{
	using QFramework;

	using UnityEngine.UI;

	/// <summary>
	/// Architecture 用于管理模块，或者说 Architecture 提供一整套架构的解决方案，而模块管理和提供 MVC 只是其功能的一小部分。
	/// </summary>
	#region 1. 定义一个 Model 对象
	public class CounterAppModel : AbstractModel
	{
		public int Count;
		protected override void OnInit()
		{
			Count = 0;
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
	public class CountAppControerMVC : MonoBehaviour, IController
	{
		// View
		private Button mBtnAdd;
		private Button mBtnSub;
		private Text mCountText;
		// 4. Model
		private CounterAppModel mModel;
		/// <summary>
		/// // 3.指定架构
		/// </summary>
		/// <returns></returns>
		public IArchitecture GetArchitecture()
		{
			return CounterApp.Interface;
		}

		void Start()
		{
			// 5. 获取模型
			mModel = this.GetModel<CounterAppModel>();

			mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
			mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
			mCountText = transform.Find("CountTxt").GetComponent<Text>();

			#region controller
			mBtnAdd.onClick.AddListener(() =>
			{
				// 交互逻辑
				this.SendCommand<IncreaseCountCommand>();
				UpdateView();
			});

			mBtnSub.onClick.AddListener(() =>
			{
				this.SendCommand<DecreaseCountCommand>();
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
			mModel = null;
		}
	}
	#endregion
	/// <summary>
	/// 引入 Command
	/// </summary>
	public class IncreaseCountCommand : AbstractCommand
	{
		protected override void OnExecute()
		{
			this.GetModel<CounterAppModel>().Count++;
		}
	}

	public class DecreaseCountCommand : AbstractCommand { protected override void OnExecute()
		{
			this.GetModel<CounterAppModel>().Count--;
		} }
}