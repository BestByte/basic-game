namespace QFramework.CountGame
{
	// 2.定义一个架构（提供 MVC、分层、模块管理等
	public class CountGame : Architecture<CountGame>
    {
        protected override void Init()
        {
            RegisterSystem<IScoreSystem>(new ScoreSystem());
            RegisterSystem<ICountDownSystem>(new CountDownSystem());
            RegisterSystem<IAchievementSystem>(new AchievementSystem());

            RegisterModel<IGameModel>(new GameModel());

            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}
