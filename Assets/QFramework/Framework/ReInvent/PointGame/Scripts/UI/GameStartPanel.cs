using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
namespace CountGame
{
    public class GameStartPanel : MonoBehaviour,IController
    {
        private IGameModel mGameModel;

        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);
                    
                    this.SendCommand<StartGameCommand>();
                });
            
           
            mGameModel = this.GetModel<IGameModel>();

           
          
            // 第一次需要调用一下
           

          
        }
        
        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "生命：" + life;
        }

        private void OnGoldValueChanged(int gold)
        {
            if (gold > 0)
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(false);
            }
          
            transform.Find("GoldText").GetComponent<Text>().text = "金币：" + gold;
        }
        
        

        private void OnDestroy()
        {
           
            mGameModel = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CountGame.Interface;
        }
    }
}
