using UnityEngine;

namespace Gametroleum.Social
{
    public interface IAchievementUpgradeStrategy
    {
        void Upgrade(Achievement achievement, AchievementProgressEntry progress);
    }

    public class NoopAchievementUpgradeStrategy : IAchievementUpgradeStrategy
    {
        public void Upgrade(
            Achievement achievement,
            AchievementProgressEntry progress)
        {
        }
    }

    public class PercentageAchievementUpgradeStrategy : IAchievementUpgradeStrategy
    {
        public void Upgrade(Achievement achievement, AchievementProgressEntry progress)
        {
            if (achievement.Type == AchievementType.NumericIncrement &&
                achievement.MaxValue != progress.MaxValue)
            {
                float percent = (float) progress.ProgressValue / (float) progress.MaxValue;
                achievement.ProgressValue = (uint) Mathf.RoundToInt(percent * achievement.MaxValue);
            }
        }
    }
}