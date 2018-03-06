namespace Gametroleum.Social
{
    // @formatter:off
    public interface ISocialManager
    {
        // All achievement changes
        event AchievementChange All;

        // Only when achievement increased by 1% or more
        event AchievementChange OnTick;

        void StartAchievements(SocialCallback callback = null, ExecutionContext ctx = null);
        void StartFeaturedStats(SocialCallback callback = null, ExecutionContext ctx = null);
        void StopAchievements(SocialCallback callback = null, ExecutionContext ctx = null);
        void StopFeaturedStats(SocialCallback callback = null, ExecutionContext ctx = null);

        void RequestAchievements(SocialResultCallback<AchievementsDefinition> callback = null, ExecutionContext ctx = null);
        
        void AchievementIncrement(string name, uint value = 1, SocialCallback callback = null, ExecutionContext ctx = null);
        void AchievementIncrementByTag(string tag, uint value = 1, SocialCallback callback = null, ExecutionContext ctx = null); 
        
        void SetPresence(string presenceId, SocialCallback callback = null, ExecutionContext ctx = null);
        
        void SetFeaturedStat(string statId, object value, SocialCallback callback = null, ExecutionContext ctx = null);
        void IncrementFeaturedStat(string statId, long value, SocialCallback callback = null, ExecutionContext ctx = null);
        void IncrementFeaturedStat(string statId, float value, SocialCallback callback = null, ExecutionContext ctx = null);
        void MinFeaturedStat(string statId, long value, SocialCallback callback = null, ExecutionContext ctx = null);
        void MinFeaturedStat(string statId, float value, SocialCallback callback = null, ExecutionContext ctx = null);
        void MaxFeaturedStat(string statId, long value, SocialCallback callback = null, ExecutionContext ctx = null);
        void MaxFeaturedStat(string statId, float value, SocialCallback callback = null, ExecutionContext ctx = null);
    }

    #pragma warning disable 0067
    public class NoopSocialManager : ISocialManager
    {
        public event AchievementChange All;
        public event AchievementChange OnTick;
        public void StartAchievements(SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void StartFeaturedStats(SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void StopAchievements(SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void StopFeaturedStats(SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void RequestAchievements(SocialResultCallback<AchievementsDefinition> callback = null, ExecutionContext ctx = null) {}

        public void AchievementIncrement(string name, uint value = 1, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void AchievementIncrementByTag(string achievementTag, uint value = 1, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void SetPresence(string presenceId, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void SetFeaturedStat(string statId, object value, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void IncrementFeaturedStat(string statId, long value, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void IncrementFeaturedStat(string statId, float value, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void MinFeaturedStat(string statId, long value, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void MinFeaturedStat(string statId, float value, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void MaxFeaturedStat(string statId, long value, SocialCallback callback = null, ExecutionContext ctx = null) {}
        public void MaxFeaturedStat(string statId, float value, SocialCallback callback = null, ExecutionContext ctx = null) {}
    }
    #pragma warning restore 0067
    // @formatter:on

    public delegate void AchievementChange(Achievement achievement);
}