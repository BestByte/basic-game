using QFramework;

namespace CountGame
{
	// 2.定义一个架构（提供 MVC、分层、模块管理等
	public class CountGame : Architecture<CountGame>
	{
		protected override void Init()
		{


			//注册system
			this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

			//注册model register  model 
			this.RegisterModel<ICountModel >(new CountModel());
			//注册utility

			this.RegisterUtility<IStorage>(new  Storage ());
		}
		/// <summary>
		/// execute command 
		/// </summary>
		/// <param name="command"></param>
		protected override void ExecuteCommand(ICommand command)
		{
			base.ExecuteCommand(command);
		}
	}
}
