using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
namespace CountGame
{
    public interface IStorage : IUtility
    {
        void  SaveInt (string key ,int  value );
        int LoadInt(string key, int defaultvalue = 0);
    }
	public class Storage : IStorage
	{
		public int LoadInt(string key, int defaultvalue = 0)
		{
			throw new System.NotImplementedException();
		}

		public void SaveInt(string key, int value)
		{
			throw new System.NotImplementedException();
		}
	}
}