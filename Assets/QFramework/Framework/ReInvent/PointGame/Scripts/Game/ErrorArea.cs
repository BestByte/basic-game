using UnityEngine;
using QFramework;
namespace CountGame
{
    public class ErrorArea : MonoBehaviour,IController
    {
        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return CountGame.Interface;
        }
    }
}
