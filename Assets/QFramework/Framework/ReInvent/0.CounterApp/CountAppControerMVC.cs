using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MVC
{
	using QFramework;
	using QFramework.Example;

	using UnityEngine.UI;

	/// <summary>
	/// Architecture ���ڹ���ģ�飬����˵ Architecture �ṩһ���׼ܹ��Ľ����������ģ�������ṩ MVC ֻ���书�ܵ�һС���֡�
	/// </summary>
	#region 1. ����һ�� Model ����
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

			//����ͨ�� CounterApp.Interface �������ݱ���¼�
			CounterApp.Interface.RegisterEvent<CountChangeEvent>(
				e =>
				{
					this.GetUtility<Storage>().SaveInt(nameof(Count), Count);
				});

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
	public class CountAppControerMVC : MonoBehaviour, IController
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
				// �����߼�
				this.SendCommand<IncreaseCountCommand>();
				
			});
         
			mBtnSub.onClick.AddListener(() =>
			{
				this.SendCommand<DecreaseCountCommand>();
				
			});
			//�����¼����� �� CQRS ԭ��֮�����ǵı����߼��Ĵ�������˺ܶࡣ��ԭ����������������,�����һ�������¼��������¼����е��á�

			UpdateView();

			 //ע���¼�
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
	/// <summary>
	/// ���� Command
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
	///  Command ������ Controller �ֵ���һ���ֵĽ����߼������Ǳ����߼��Ĵ���Ŀǰ�����������Ǻ����ܡ�
	/// </summary>
	public class DecreaseCountCommand : AbstractCommand { protected override void OnExecute()
		{
			this.GetModel<CounterAppModel>().Count--;
			this.SendEvent<CountChangeEvent>();
		} }
	/// <summary>
	/// �������ݱ���¼�
	/// </summary>
	public struct CountChangeEvent
	{

	}
}