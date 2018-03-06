using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gametroleum.Social
{
    [Serializable]
    public class Achievement
    {
        [SerializeField]
        public int Id;

        [SerializeField]
        public string Name;

        [SerializeField]
        public string Tag;

        [SerializeField]
        public AchievementType Type;

        [SerializeField]
        public Texture AchievedIcon;

        [SerializeField]
        public string DeepLink;

        [SerializeField]
        public string Description;

        [SerializeField]
        public int EstimatedTimeSeconds;

        [SerializeField]
        public string ExternalId;

        [SerializeField]
        public string ExternalName;

        [SerializeField]
        public bool Hidden;

        [SerializeField]
        public bool DefinedLocked;

        [SerializeField]
        public uint MaxValue;

        [SerializeField]
        public string NotAchievedDescription;

        [SerializeField]
        public List<string> Properties = new List<string>();

        [SerializeField]
        public Texture UnachievedIcon;

        [SerializeField]
        public string UnlockingProduct;

        [SerializeField]
        public List<int> Unlocks = new List<int>();

        #region Progress Data

        [SerializeField]
        public bool Locked;

        [SerializeField]
        public bool Achieved;

        [SerializeField]
        public uint ProgressValue;

        #endregion

        public override string ToString()
        {
            return string.Format("Achievement Id: {0}, Name: {1}", Id, Name);
        }
    }
    
    [Serializable]
    public class AchievementProgressEntry
    {
        [SerializeField]
        public int AchievementId;

        [SerializeField]
        public bool Locked;

        [SerializeField]
        public bool Achieved;

        [SerializeField]
        public uint ProgressValue;

        [SerializeField]
        public uint MaxValue;

        [SerializeField]
        public AchievementType Type;
    }

    public enum AchievementType
    {
        NumericIncrement = 0,
        OneShot = 1
    }
}