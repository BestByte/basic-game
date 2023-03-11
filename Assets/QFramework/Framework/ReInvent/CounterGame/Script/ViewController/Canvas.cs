using UnityEngine;
using QFramework;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace CountGame 
{
	public partial class Canvas : ViewController,IController
	{
		private ICountModel countModel;
		void Start()
		{
			// Code Here
			ButtonAdd.onClick.AddListener(() =>
			{
				this.SendCommand<IncreaseCountCommand>();
			});

			ButtonSub.onClick.AddListener(() =>
			{
				this.SendCommand<DecreaseCountCommand>(); ;
			});
			countModel.Count.RegisterWithInitValue(newCunt =>
			{
				UpdateView();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

		void UpdateView()
		{
			CountText.text = countModel.Count.ToString();
		}
		public IArchitecture GetArchitecture()
		{
			return CountGame.Interface;
		}

	}
}
