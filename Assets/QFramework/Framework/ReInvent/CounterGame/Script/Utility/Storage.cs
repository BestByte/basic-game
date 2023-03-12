using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Unity.VisualScripting;

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
			return PlayerPrefs.GetInt(key, defaultvalue);
		}

		public void SaveInt(string key, int value)
		{
			PlayerPrefs.SetInt(key, value);
		}
	}
}