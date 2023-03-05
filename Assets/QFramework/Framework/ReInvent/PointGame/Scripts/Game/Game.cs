using UnityEngine;
using QFramework;
namespace CountGame
{
    /// <summary>
    /// controller
    /// </summary>
    public class Game : MonoBehaviour,IController
    {
        private void Awake()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
            
          
        }
        
        private void OnGameStart(GameStartEvent e)
        {
           
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEvent>(OnGameStart);
        }

        public IArchitecture GetArchitecture()
        {
            return CountGame.Interface;
        }
    }
}