using UnityEngine;
using QFramework;
namespace CountGame
{
    public class Game : MonoBehaviour,IController
    {
        private void Awake()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
            
          
        }
        
        private void OnGameStart(GameStartEvent e)
        {
            var enemyRoot = transform.Find("Enemies");
          
            enemyRoot.gameObject.SetActive(true);

            foreach (Transform childTrans in enemyRoot)
            {
                childTrans.gameObject.SetActive(true);
            }
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