using QFramework;

namespace CountGame
{
	// 2.����һ���ܹ����ṩ MVC���ֲ㡢ģ������
	public class CountGame : Architecture<CountGame>
	{
		protected override void Init()
		{


			//ע��system
			this.RegisterSystem<IAchievementSystem>(new AchievementSystem());

			//ע��model
			this.RegisterModel<ICountModel >(new CountModel());
			//ע��utility

		}
	}
}
