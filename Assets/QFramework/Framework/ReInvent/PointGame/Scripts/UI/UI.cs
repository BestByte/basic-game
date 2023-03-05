using UnityEngine;

namespace CountGame
{
    using QFramework;
    public class UI : MonoBehaviour,IController
    {
        void Start()
        {
            this.RegisterEvent<GamePassEvent>(OnGamePass);
            
           
        }

        private void OnGamePass(GamePassEvent e)
        {
           
        }

        void OnDestroy()
        {
           
        }

        public IArchitecture GetArchitecture()
        {
            return CountGame.Interface;
        }
    }
}