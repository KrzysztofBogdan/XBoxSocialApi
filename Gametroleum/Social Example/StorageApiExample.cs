#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif
using System.Collections;
using System.Linq;
using Gametroleum.Social;
using UnityEngine;
#if XBOXONE
using Users;

#endif

public class StorageApiExample : MonoBehaviour
{
#if XBOXONE
    private XBoxStorage _xBoxStorage;

    private void Start()
    {
        StartCoroutine(PrintXbox());
    }

    private void Update()
    {
        if (_xBoxStorage != null) _xBoxStorage.Update();
    }

    private IEnumerator PrintXbox()
    {
        Debug.Log(" -- PrintXbox Call Start");

        yield return new WaitForEndOfFrame();

        Debug.Log(" -- PrintXbox WaitForEndOfFrame");

        yield return StorageHelperApiExample();

        Debug.Log(" -- PrintXbox Call End");
    }

    private IEnumerator StorageHelperApiExample()
    {
        Debug.Log(" -- UsersManager.IsSomeoneSignedIn = " + UsersManager.IsSomeoneSignedIn);

        if (!UsersManager.IsSomeoneSignedIn) UsersManager.RequestSignIn(AccountPickerOptions.AllowGuests);

        if (UsersManager.Users.Count == 0)
        {
            Debug.Log(" -- PrintXbox Call End == NO USER!");
            yield break;
        }

        Debug.Log(" -- PrintXbox UsersManager.Users.Count = " + UsersManager.Users.Count);

        var user = UsersManager.Users[0];

        var pp = "-- PrintXbox -| ";

        _xBoxStorage = new XBoxStorage("00-pp-achievements");
        Debug.Log(pp + " Test Storage Helper --");
        _xBoxStorage.Query(user.Id, "does-NOT-exists", result =>
        {
            if (result.IsSuccess)
                Debug.Log(pp + "Query (does-NOT-exists) entries: " + result.Data.TotalResults);
            else
                Debug.LogError(pp + "Query (does-NOT-exists) Failed!");
        });

        var oneMegabyte = 1024 * 1024;
        _xBoxStorage.Load(user.Id, "does-NOT-exists", oneMegabyte, result =>
        {
            if (result.IsSuccess)
                Debug.Log(pp + "(does-NOT-exists) Loaded: " + result.Data.AsUtf8String());
            else
                Debug.LogError(pp + "(does-NOT-exists) Failed to load");
        });

        _xBoxStorage.Save(user.Id, "does-exists", "some-data".AsUtf8(), result =>
        {
            if (result.IsSuccess)
                Debug.Log(pp + "Saved (does-exists) ");
            else
                Debug.LogError(pp + "Saved (does-exists) Failed!");
        });

        _xBoxStorage.Load(user.Id, "does-exists", oneMegabyte, result =>
        {
            if (result.IsSuccess)
                Debug.Log(pp + "(does-exists) Loaded: " + result.Data.AsUtf8String());
            else
                Debug.LogError(pp + "(does-exists) Failed to load");
        });

        _xBoxStorage.Query(user.Id, "does-", result =>
        {
            if (result.IsSuccess)
                if (result.Data != null && result.Data.TotalResults > 0)
                {
                    var names = string.Join(",", result.Data.Query.Select(it => it.Name).ToArray());
                    Debug.Log(pp + "Query (does-) names: " + names);
                }
                else
                {
                    Debug.LogError(pp + "Query (does-) no entries?!");
                }
            else
                Debug.LogError(pp + "Query (does-) Failed!");
        });

        _xBoxStorage.Delete(user.Id, new[] {"does-exists"}, result =>
        {
            if (result.IsSuccess)
                Debug.Log(pp + "Delete (does-exists) Successed");
            else
                Debug.LogError(pp + "Delete (does-exists) Failed");
        });

        _xBoxStorage.Load(user.Id, "does-exists", oneMegabyte, result =>
        {
            if (result.IsSuccess)
                Debug.LogError(pp + "Deleted (does-exists) Loaded: " + result.Data.AsUtf8String());
            else
                Debug.Log(pp + "Deleted (does-exists) can not be loaded, all good.");
        });
    }

#endif
}