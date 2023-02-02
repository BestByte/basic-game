using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Reinvent { 
public class CounterAppController : MonoBehaviour
{
        #region view

        private Button mBtnAdd;
        private Button mBtnSub;
        private Text mCounterTxt;

        #endregion

        #region model
        private int mCount=0;
		#endregion
		// Start is called before the first frame update
		void Start()
    {
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub=transform.Find("BtnSub").GetComponent<Button>();
            mCounterTxt=transform.Find("CountTxt").GetComponent<Text>();

			#region controller
			mBtnAdd.onClick.AddListener(() =>
            {
                mCount++;
                UpdateView();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                mCount--;
                UpdateView();
            });
			#endregion
		}

		private void UpdateView()
		{
			mCounterTxt.text = mCount.ToString();
		}

		
}
}

namespace QFramework.MVC
{

}