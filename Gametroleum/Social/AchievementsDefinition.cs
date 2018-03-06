using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gametroleum.Social
{
    [Serializable]
    [CreateAssetMenu(fileName = "Achievements Definition", menuName = "Achievements Definition", order = 1)]
    public class AchievementsDefinition : ScriptableObject
    {
        [SerializeField]
        public List<Achievement> Achievements = new List<Achievement>();

        public void Add(Achievement achievementConfig)
        {
            Achievements.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));

            int id = Achievements.Count;
            for (int index = 0; index < Achievements.Count; index++)
            {
                if (Achievements[index].Id != index)
                {
                    id = index;
                    break;
                }
            }

            achievementConfig.Id = id;
            Achievements.Add(achievementConfig);
        }

        public AchievementsDefinition Clone()
        {
            return Instantiate(this);
        }
    }
}