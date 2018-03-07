#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif

using System.Collections;
using Gametroleum.Social;
using UnityEngine;
#if XBOXONE
using Users;

#endif

namespace Gametroleum.AchievementsExample
{
    public class SocialProRichPresenceExample : SocialExampleComponent
    {
        public SocialPro Social;

#if XBOXONE
        protected override IEnumerator RunExample()
        {
            Log("UsersManager.IsSomeoneSignedIn = " + UsersManager.IsSomeoneSignedIn);

            if (!UsersManager.IsSomeoneSignedIn) UsersManager.RequestSignIn(AccountPickerOptions.AllowGuests);

            if (UsersManager.Users.Count == 0)
            {
                Log("No user! Abort! ");
                yield break;
            }

            Log(UsersManager.Users.Count);

            Social.SetPresence("game1_5", it => { Log("[game1_5] ->" + it.IsSuccess); });

            yield return new WaitForSeconds(40.0f);

            Social.SetPresence("game5_10", it => { Log("[game5_10] ->" + it.IsSuccess); });
        }
#endif
    }
}