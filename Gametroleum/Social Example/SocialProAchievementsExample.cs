#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif
using System.Collections;
using Gametroleum.Social;
using UnityEngine;

namespace Gametroleum.AchievementsExample
{
    public class SocialProAchievementsExample : SocialExampleComponent
    {
        public SocialPro Social;
        
#if XBOXONE
        protected override IEnumerator RunExample()
        {
            Social.StartAchievements(it => { Log(" [StartAchievements] ~ " + it.IsSuccess); });

            for (int i = 0; i < 5; i++)
            {
                var index = i;
                
                Social.AchievementIncrement("I like this game", 20,
                    achievementIncrementResult =>
                    {
                        Log("[AchievementIncrement][" + index + "] ~ " + achievementIncrementResult.IsSuccess);
                    });
                
                yield return new WaitForSeconds(5.0f);
                
            }
            
            Social.StopAchievements(it => { Log(" [StopAchievements] ~ " + it.IsSuccess); });
            
            Social.StartAchievements(it => { Log(" [StartAchievements] ~ " + it.IsSuccess); });
            
            for (int i = 0; i < 5; i++)
            {
                var index = i;
                
                Social.AchievementIncrementByTag("survive", 5,
                    achievementIncrementResult =>
                    {
                        Log("[AchievementIncrement][" + index + "] ~ " + achievementIncrementResult.IsSuccess);
                    });
                
                yield return new WaitForSeconds(5.0f);
                
            }

        }
#endif
    }
}