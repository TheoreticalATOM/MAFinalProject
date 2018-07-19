using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameGrind
{
    public class Journal : MonoBehaviour
    {
        // This list contains every achievement in your game
        public static List<Achievement> achievementMaster = new List<Achievement>();
        public AchievementUIList achievementUI;
        public static string saveDataPath = "/SaveData/Achievements/";

        /// <summary>
        /// Create a new achievement to allow tracking
        /// </summary>
        /// <param name="stat">Stat object to track.</param>
        public static void Create(Achievement stat)
        {
            // Add the new stat to the master stat list
            achievementMaster.Add(stat);
        }

        /// <summary>
        /// Increment the achievement progress value based on a float amount
        /// </summary>
        /// <param name="id">Int identifier.</param>
        /// <param name="amount">Amount to increment by.</param>
        public static void Increment(int id, int amount)
        {
            Achievement achievement = GetAchievement(id);
            if (achievement == null)
            {
                Debug.LogWarningFormat("Achievement {0} could not be found. Double check your IDs in the Journal Manager.", id);
            }
            Increment(achievement, amount);
        }

        /// <summary>
        /// Increment the achievement progress value based on a float amount
        /// </summary>
        /// <param name="id">String identifier.</param>
        /// <param name="amount">Amount to increment by.</param>
        public static void Increment(string title, int amount)
        {
            Achievement achievement = GetAchievement(title);
            if (achievement == null)
            {
                Debug.LogWarningFormat("Achievement {0} could not be found. Make sure the achievement title matches the data in Journal Manager", title);
            }
            Increment(achievement, amount);
        }

        /// <summary>
        /// Increment the achievement progress value based on a float amount
        /// </summary>
        /// <param name="achievement">Achievement object.</param>
        /// <param name="amount">Amount to increment by.</param>
        public static void Increment(Achievement achievement, int amount)
        {
            if (achievement.value < achievement.neededValue)
            {
                achievement.value += amount;
                AchievementController.CheckForCompletion(achievement);
                AchievementEvents.AchievementValueChanged(achievement);
            }

        }

        /// <summary>
        /// Set an achievement's progress value directly
        /// </summary>
        /// <param name="id">Achievement ID.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="triggerGrant">Whether to trigger achievement notification if completed.</param>
        public static void SetValue(int id, int value, bool triggerGrant = true)
        {
            Achievement achievement = GetAchievement(id);
            SetValue(achievement, value, triggerGrant);
        }

        /// <summary>
        /// Set an achievement's progress value directly
        /// </summary>
        /// <param name="title">Achievement name.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="triggerGrant">Whether to trigger achievement notification if completed.</param>
        public static void SetValue(string title, int value, bool triggerGrant = true)
        {
            Achievement achievement = GetAchievement(title);
            SetValue(achievement, value, triggerGrant);
        }

        /// <summary>
        /// Set an achievement's progress value directly
        /// </summary>
        /// <param name="achievement">Achievement object.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="triggerGrant">Whether to trigger achievement notification if completed.</param>
        public static void SetValue(Achievement achievement, int value, bool triggerGrant = true)
        {
            achievement.value = value;
            if (achievement.value >= achievement.neededValue)
            {
                achievement.completed = true;
            }
            if (triggerGrant)
            {
                AchievementController.CheckForCompletion(achievement);
            }
            AchievementEvents.AchievementValueChanged(achievement);
        }

        /// <summary>
        /// Decrease the achievement progress value based on a float amount
        /// </summary>
        /// <param name="id">Int identifier.</param>
        /// <param name="amount">Amount to decrease by.</param>
        public static void Decrease(int id, int amount)
        {
            Achievement achievement = GetAchievement(id);
            if (achievement == null)
            {
                Debug.LogWarningFormat("Achievement {0} could not be found. Double check your IDs in the Journal Manager.", id);
            }
            Decrease(achievement, amount);
        }

        /// <summary>
        /// Decrease the achievement progress value based on a float amount
        /// </summary>
        /// <param name="id">String identifier.</param>
        /// <param name="amount">Amount to decrease by.</param>
        public static void Decrease(string title, int amount)
        {
            Achievement achievement = GetAchievement(title);
            if (achievement == null)
            {
                Debug.LogWarningFormat("Achievement {0} could not be found. Make sure the achievement title matches the data in Journal Manager", title);
            }
            Decrease(achievement, amount);
        }

        /// <summary>
        /// Decrease the achievement progress value based on a float amount
        /// </summary>
        /// <param name="achievement">Achievement object.</param>
        /// <param name="amount">Amount to decrease by.</param>
        public static void Decrease(Achievement achievement, int amount)
        {
            if (achievement.value > 0)
            {
                achievement.value -= amount;
            }
            AchievementController.CheckForCompletion(achievement);
            AchievementEvents.AchievementValueChanged(achievement);
        }

        /// <summary>
        /// Get the achievement
        /// </summary>
        /// <returns>The achievement.</returns>
        /// <param name="id">identifier.</param>
        public static Achievement GetAchievement(int id)
        {
            foreach (Achievement achievement in achievementMaster)
            {
                if (achievement.id == id)
                    return achievement;
            }
            // If requested stat doesn't exist return an empty Stat and send a warning
            Debug.LogWarning("Stat " + id + " doesn't exist!");
            return null;
        }

        /// <summary>
        /// Get the achievement
        /// </summary>
        /// <returns>The achievement.</returns>
        /// <param name="title">String identifier.</param>
        public static Achievement GetAchievement(string title)
        {
            foreach (Achievement achievement in achievementMaster)
            {
                if (achievement.title == title)
                    return achievement;
            }
            // If requested stat doesn't exist return an empty Stat and send a warning
            Debug.LogWarning("Stat \"" + title + "\" doesn't exist!");
            return null;
        }

        /// <summary>
        /// Gets the achievement progress value
        /// </summary>
        /// <returns>The achievement value.</returns>
        /// <param name="id">Int identifier.</param>
        public static float GetAchievementValue(int id)
        {
            return GetAchievement(id).value;
        }

        /// <summary>
        /// Gets the achievement progress value
        /// </summary>
        /// <returns>The achievement value.</returns>
        /// <param name="title">String identifier.</param>
        public static float GetAchievementValue(string title)
        {
            return GetAchievement(title).value;
        }

        /// <summary>
        /// Get achievement score value
        /// </summary>
        /// <returns>Achievement score.</returns>
        public static int GetAchievementScore()
        {
            return AchievementController.CurrentAchievementScore;
        }

        /// <summary>
        /// Saves the achievement progress data using JsonUtility
        /// You can change the desired save/load path in AchievementController.cs
        /// </summary>
        public static void Save()
        {
            AchievementProgressDataCollection progressCollection = new AchievementProgressDataCollection();
            foreach(Achievement achievement in achievementMaster)
            {
                progressCollection.achievementProgressList.Add(new AchievementProgressData(achievement.id, achievement.value));
            }
            string jsonString = JsonUtility.ToJson(progressCollection, true);

            // This method creates the directory for the data IF it doesn't already exist.
            // No explicit check required.
            Directory.CreateDirectory(Application.persistentDataPath + saveDataPath);
            File.WriteAllText(Application.persistentDataPath + saveDataPath + "/achievement-save.json", jsonString);
        }

        /// <summary>
        /// Check to see if a save file already exists
        /// </summary>
        public static bool SaveExists()
        {
            return File.Exists(Application.persistentDataPath + saveDataPath + "/achievement-save.json");
        }

        public static void DeleteSave()
        {
            if (SaveExists())
            {
                File.Delete(Application.persistentDataPath + saveDataPath + "/achievement-save.json");
            }
        }

        /// <summary>
        /// Loads the achievement data using JsonUtility
        /// You can change the desired save/load path in AchievementController.cs
        /// </summary>
        public static void Load()
        {
            if (SaveExists())
            {
                AchievementProgressDataCollection progressCollection = JsonUtility.FromJson<AchievementProgressDataCollection>
                    (File.ReadAllText(Application.persistentDataPath + saveDataPath + "/achievement-save.json"));
                for (int i = 0; i < achievementMaster.Count ; i++)
                {
                    SetValue(progressCollection.achievementProgressList[i].id, progressCollection.achievementProgressList[i].value, false);
                }
                
            }
        }

        /// <summary>
        /// Reset all achievement progress values, including revoking all completed achievements
        /// </summary>
        public static void ResetAllStats()
        {
            achievementMaster.ForEach(i => { i.value = 0; i.completed = false; });
            Save();
        }
    }
}