using UnityEngine;

namespace QFramework.CountGame
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);
        int LoadInt(string key, int defaultValue = 0);
    }

   
}