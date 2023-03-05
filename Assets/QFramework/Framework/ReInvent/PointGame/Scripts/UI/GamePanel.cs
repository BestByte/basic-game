using UnityEngine;
using UnityEngine.UI;
using QFramework;
namespace CountGame   
{
    public class GamePanel : MonoBehaviour, IController
    {
       
        private IGameModel mGameModel;

        private void Awake()
        {
          

            mGameModel = this.GetModel<IGameModel>();

           

            // 第一次需要调用一下
          
           // OnScoreValueChanged(mGameModel.Score.Value);
        }

       

        private void OnScoreValueChanged(int score)
        {
            transform.Find("ScoreText").GetComponent<Text>().text = "分数:" + score;
        }

        private void Update()
        {
          
        }

        private void OnDestroy()
        {
           
           
            mGameModel = null;
           
        }

        public IArchitecture GetArchitecture()
        {
            return CountGame.Interface;
        }
    }
}