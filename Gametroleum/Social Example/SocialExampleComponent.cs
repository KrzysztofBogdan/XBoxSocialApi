#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif
using System.Collections;
using UnityEngine;
#if XBOXONE
using Users;

#endif

namespace Gametroleum.AchievementsExample
{
    public abstract class SocialExampleComponent : MonoBehaviour
    {
        public bool Enable = true;
        public string MessagePrefix = "[Social Example] -| ";

#if XBOXONE
        private bool _userOn = true;
#endif

        protected void Log(object message)
        {
            Debug.Log(MessagePrefix + message);
        }

        private IEnumerator Start()
        {
            if (!Enable)
            {
                yield break;
            }

            Log("Begin");

            yield return new WaitForEndOfFrame();

#if XBOXONE
            yield return Precondition();

            if (_userOn)
            {
                yield return RunExample();
            }
#else
            Log("You need to run this example on XBox");
#endif

            Log("END");
        }

#if XBOXONE
        private IEnumerator Precondition()
        {
            if (!UsersManager.IsSomeoneSignedIn)
            {
                UsersManager.RequestSignIn(AccountPickerOptions.AllowGuests);
            }

            if (UsersManager.Users.Count == 0)
            {
                Log("Still not user. Stop");
                _userOn = false;
                yield break;
            }

            Log(UsersManager.Users.Count);
            yield return new WaitForEndOfFrame();
        }

        protected abstract IEnumerator RunExample();
#endif
    }
}