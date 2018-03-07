#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif

using Gametroleum.Social;
using UnityEngine;

namespace Gametroleum.AchievementsExample
{
    public class SocialProXBoxLifecycle : MonoBehaviour
    {
        public SocialPro Social;

#if XBOXONE
        private void Start()
        {
            XboxOnePLM.OnSuspendingEvent += OnSuspendingEvent;
        }

        private void OnSuspendingEvent()
        {
            // Clean up XBoxManager and game related information here
            // after that you should call XboxOnePLM.AmReadyToSuspendNow()
            
            Social.XBoxManager.Flush(result => { XboxOnePLM.AmReadyToSuspendNow(); });
        }
#endif
    }
}