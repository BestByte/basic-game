namespace CountGame
{
    using QFramework;
    public interface IGameModel : IModel
    {
       
      

       BindableProperty<int> Count { get; }

    }

    public class GameModel : AbstractModel, IGameModel
    {
       
        public BindableProperty<int> Count { get; }=new BindableProperty<int>();
		protected override void OnInit()
        {
            
        }
    }
}