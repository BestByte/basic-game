namespace CountGame
{
    using QFramework;
    public class StartGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            // 重置数据
            var gameModel = this.GetModel<IGameModel>();
          
        
            
            this.SendEvent<GameStartEvent>();
        }
    }
}