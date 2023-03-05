using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using QFramework;
namespace CountGame
{
    public interface IAchievementSystem : ISystem
    {
    }

    public class AchievementItem
    {
        public string Name { get; set; }

        public Func<bool> CheckComplete { get; set; }

        public bool Unlocked { get; set; }
    }


    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        private List<AchievementItem> mItems = new List<AchievementItem>();

        private bool mMissed = false;
        protected override void OnInit()
        {
           
            this.RegisterEvent<GameStartEvent>(e =>
            {
                mMissed = false;
            });

          
          
            // 成就系统一般是持久化的，所以如果需要持久化也是在这个时机进行，可以让 Unlocked 变成 BindableProperty

            
        }
    }
}