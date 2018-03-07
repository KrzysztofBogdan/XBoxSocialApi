#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif
using System.Collections;
using Gametroleum.Social;
using UnityEngine;

namespace Gametroleum.AchievementsExample
{
    public class SocialProFeaturedStatsExample : SocialExampleComponent
    {
        public SocialPro Social;

#if XBOXONE
        protected override IEnumerator RunExample()
        {
            Social.StartFeaturedStats(delegate(ActionResult it) { Log(" [StartFeaturedStats] ~" + it.IsSuccess); });
    
            Social.SetFeaturedStat("alive", 20L, it => Log(" [SetFeaturedStat][20] ~" + it.IsSuccess));
            yield return new WaitForSeconds(20.0f);

            Social.SetFeaturedStat("alive", 60L, it => Log(" [SetFeaturedStat][60] ~" + it.IsSuccess));

            yield return new WaitForSeconds(20.0f);

            Social.SetFeaturedStat("alive", 80L, it => Log(" [SetFeaturedStat][80] ~" + it.IsSuccess));

            Social.StopFeaturedStats(delegate(ActionResult it) { Log(" [StopFeaturedStats] ~" + it.IsSuccess); });

            yield return new WaitForSeconds(1.0f);

            Social.StartFeaturedStats(delegate(ActionResult it) { Log(" [StartFeaturedStats] ~" + it.IsSuccess); });
            
            yield return new WaitForSeconds(20.0f);

            Social.SetFeaturedStat("alive", 100L, it => Log(" [StartFeaturedStats][100] ~" + it.IsSuccess) );
        }
#endif

    }
}