#if UNITY_XBOXONE && !UNITY_EDITOR
#define XBOXONE
#endif

using System.Collections.Generic;
using System.Text;
using UnityEngine;
#if XBOXONE
using ConsoleUtils;
using DataPlatform;
using Storage;
using Users;

#endif

namespace Gametroleum.Social
{
    public class SocialPro : MonoBehaviour, ISocialManager
    {
        public MonoBehaviour[] BeforeAwake;
        public MonoBehaviour[] AfterAwake;

        private ISocialManager _manager = new NoopSocialManager();
        public AchievementsDefinition Data;
        public string XBoxConnectedStorageBlobName = "achievements-progress";
        public int XBoxConnectedStorageBlobSize = 10485760; // 1 Megabyte = 1,048,576 Bytes
        public string XBoxConnectedStorageContainerName = "00-pp-achievements";
        public bool XBoxEnableAchievementsManager = true;
        public bool XBoxEnableConsoleUtilsManager = true;
        public bool XBoxEnableDataPlatformPlugin = true;
        public bool XBoxEnableStatisticsManager = true;
        public bool XBoxEnableStorageManager = true;
        public bool XBoxEnableUsersManager = true;
        public int XBoxSaveProgressToConnectedStorageInSeconds = 60 * 5; // Default every 5 minutes
        public bool XBoxEnableDebug = true;
        public NoopAchievementUpgradeStrategy AchievementUpgradeStrategy = new NoopAchievementUpgradeStrategy();

        public event AchievementChange All
        {
            add { _manager.All += value; }
            remove { _manager.All -= value; }
        }

        public event AchievementChange OnTick
        {
            add { _manager.OnTick += value; }
            remove { _manager.OnTick -= value; }
        }

        public void StartAchievements(SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.StartAchievements(onResult, ctx);
        }

        public void StartFeaturedStats(SocialCallback onResult = null, ExecutionContext ctx = null)
        {
            _manager.StartFeaturedStats(onResult, ctx);
        }

        public void StopAchievements(SocialCallback callback = null, ExecutionContext ctx = null)
        {
            _manager.StopAchievements(callback, ctx);
        }

        public void StopFeaturedStats(SocialCallback callback = null, ExecutionContext ctx = null)
        {
            _manager.StopFeaturedStats(callback, ctx);
        }

        public void RequestAchievements(SocialResultCallback<AchievementsDefinition> callback = null, ExecutionContext ctx = null)
        {
            _manager.RequestAchievements(callback, ctx);
        }

        public void AchievementIncrement(string achievementName, uint value = 1, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.AchievementIncrement(achievementName, value, onResult, ctx);
        }

        public void AchievementIncrementByTag(string achievementTag, uint value = 1, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.AchievementIncrementByTag(achievementTag, value, onResult, ctx);
        }

        public void SetPresence(string presenceId, SocialCallback onResult = null, ExecutionContext ctx = null)
        {
            _manager.SetPresence(presenceId, onResult, ctx);
        }

        public void SetFeaturedStat(string statId, object value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.SetFeaturedStat(statId, value, onResult, ctx);
        }

        public void IncrementFeaturedStat(string statId, long value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.IncrementFeaturedStat(statId, value, onResult, ctx);
        }

        public void IncrementFeaturedStat(string statId, float value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.IncrementFeaturedStat(statId, value, onResult, ctx);
        }

        public void MinFeaturedStat(string statId, long value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.MinFeaturedStat(statId, value, onResult, ctx);
        }

        public void MinFeaturedStat(string statId, float value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.MinFeaturedStat(statId, value, onResult, ctx);
        }

        public void MaxFeaturedStat(string statId, long value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.MaxFeaturedStat(statId, value, onResult, ctx);
        }

        public void MaxFeaturedStat(string statId, float value, SocialCallback onResult = null,
            ExecutionContext ctx = null)
        {
            _manager.MaxFeaturedStat(statId, value, onResult, ctx);
        }

#if XBOXONE
        public XBoxSocialManager XBoxManager;

        private void Awake()
        {
            foreach (var mb in BeforeAwake)
            {
                mb.SendMessage("BeforeAwake", this);
            }

            if (XBoxEnableDataPlatformPlugin) DataPlatformPlugin.InitializePlugin(0);
            if (XBoxEnableStorageManager) StorageManager.Create();
            if (XBoxEnableAchievementsManager) AchievementsManager.Create();
            if (XBoxEnableConsoleUtilsManager) ConsoleUtilsManager.Create();
            if (XBoxEnableUsersManager) UsersManager.Create();
            if (XBoxEnableStatisticsManager) StatisticsManager.Create();

            _manager = XBoxManager = new XBoxSocialManager();

            XBoxManager.Start(Data,
                XBoxConnectedStorageContainerName,
                XBoxConnectedStorageBlobName,
                XBoxConnectedStorageBlobSize,
                this,
                XBoxEnableDebug,
                AchievementUpgradeStrategy
            );

            InvokeRepeating("XboxSaveProgress",
                XBoxSaveProgressToConnectedStorageInSeconds,
                XBoxSaveProgressToConnectedStorageInSeconds);

            foreach (var mb in AfterAwake)
            {
                mb.SendMessage("AfterAwake", this);
            }
        }

        private void XboxSaveProgress()
        {
            XBoxManager.PersistAchievements();
        }

        private void Update()
        {
            XBoxManager.Update();
        }
#endif
    }

    internal static class ObjHelper
    {
        public static byte[] AsUtf8(this string @this)
        {
            return Encoding.UTF8.GetBytes(@this);
        }

        public static string AsUtf8String(this byte[] @this)
        {
            return Encoding.UTF8.GetString(@this);
        }

        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue = default(TV))
        {
            TV value;
            return dict.TryGetValue(key, out value) ? value : defaultValue;
        }
    }

    public interface ITask
    {
        void Run();
    }
}