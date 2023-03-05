using UnityEngine;

namespace CountGame
{
    using QFramework;
    public class UI : MonoBehaviour,IController
    {
        void Start()
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