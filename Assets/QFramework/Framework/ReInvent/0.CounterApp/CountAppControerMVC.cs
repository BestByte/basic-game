using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MVC
{
	using QFramework;
	using QFramework.Example;
	using UnityEngine.UI;

	/// <summary>
	/// Architecture 用于管理模块，或者说 Architecture 提供一整套架构的解决方案，而模块管理和提供 MVC 只是其功能的一小部分。
	/// </summary>
	#region 1. 定义一个 Model 对象
	public class CounterAppModel : AbstractModel
	{
		private int mCount;
		public int Count
		{
			get => mCount;
			set
			{
				if (mCount != value)
				{
					mCount = value;
					PlayerPrefs.SetInt(nameof(mCount), mCount);
				}
			}
		}
		protected override void OnInit()
		{
			var storage = this.GetUtility<Storage>();
			Count=storage.LoadInt(nameof(Count));

			//可以通过 CounterApp.Interface 监听数据变更事件
			CounterApp.Interface.RegisterEvent<CountChangeEvent>(
				e =>
				{
					this.GetUtility<Storage>().SaveInt(nameof(Count), Count);
				});

		}

	}
	#endregion

	#region  2.定义一个架构（提供 MVC、分层、模块管理等）
	public class CounterApp : Architecture<CounterApp>
	{
		/// <summary>
		/// 架构初始化
		/// </summary>
		protected override void Init()
		{
			// 注册 Model
			this.RegisterModel(new CounterAppModel());
			// 注册存储工具的对象
			this.RegisterUtility(new  Storage());
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
				
			});
         
			mBtnSub.onClick.AddListener(() =>
			{
				this.SendCommand<DecreaseCountCommand>();
				
			});
			//引入事件机制 和 CQRS 原则之后，我们的表现逻辑的代码变少了很多。由原来的两次主动调用,变成了一处监听事件，接收事件进行调用。

			UpdateView();

			 //注册事件
			this.RegisterEvent<CountChangeEvent>(e =>
			{
				UpdateView();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
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

	#region 引入 Command

	
	/// <summary>
	/// 引入 Command
	/// </summary>
	public class IncreaseCountCommand : AbstractCommand
	{
		protected override void OnExecute()
		{
			this.GetModel<CounterAppModel>().Count++;
			this.SendEvent<CountChangeEvent>();
		}
	}
	/// <summary>
	///  Command 来帮助 Controller 分担了一部分的交互逻辑。但是表现逻辑的代码目前看起来并不是很智能。
	/// </summary>
	public class DecreaseCountCommand : AbstractCommand { protected override void OnExecute()
		{
			this.GetModel<CounterAppModel>().Count--;
			this.SendEvent<CountChangeEvent>();
		} }
	#endregion

	#region  定义数据变更事件
	
	/// <summary>
	/// 定义数据变更事件
	/// </summary>
	public struct CountChangeEvent
	{

	}
	#endregion

	#region 定义 utility 层
	/// <summary>
	/// 定义 utility 层
	/// </summary>
	public class Storage : IUtility
	{
		public void SaveInt(string key,int value)
		{
			PlayerPrefs.SetInt(key, value);
		}
	/// <summary>
	/// 载入int数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="value"></param>
	/// <returns></returns>
		public int LoadInt(string key,int value = 0)
		{
			return PlayerPrefs.GetInt(key, value);
		}
	}
	#endregion

	#region 定义System
	public class AchievementSystem : AbstractSystem
	{

	}
	
	#endregion
}