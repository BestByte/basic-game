using QFramework;

namespace CountGame
{
	// 2.定义一个架构（提供 MVC、分层、模块管理等
	public class CountGame : Architecture<CountGame>
    {
        protected override void Init()
        {


            //注册system

            //注册model
            this.RegisterModel<IGameModel>(new GameModel());
            //注册utility
            
        }
    }
}
