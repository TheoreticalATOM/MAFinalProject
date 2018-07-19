using UnityEngine;

namespace GameGrind
{
    public class AchievementEvents : MonoBehaviour
    {
        /// <summary>
        /// Event handler for updating data based on achievement stat changes
        /// </summary>
        public delegate void AchievementValueChange(GameGrind.Achievement achievement);

        /// <summary>
        /// Event handler for granted achievements
        /// </summary>
        /// <param name="achievement">The achievement that was granted</param>
        public delegate void AchievementGrant(GameGrind.Achievement achievement);

        /// <summary>
        /// Event that gets called when an achievement value is changed
        /// </summary>
        public static event AchievementValueChange OnAchievementChange;

        /// <summary>
        /// Event that gets called when an achievement is granted
        /// </summary>
        public static event AchievementGrant OnAchievementGrant;

        /// <summary>
        /// Handler called when achievement values are changed
        /// </summary>
        public static void AchievementValueChanged(GameGrind.Achievement achievement)
        {
            if (OnAchievementChange != null)
                OnAchievementChange(achievement);
        }

        /// <summary>
        /// Handler called when achievement has been completed
        /// </summary>
        /// <param name="achievement"></param>
        public static void AchievementGranted(GameGrind.Achievement achievement)
        {
            if (OnAchievementGrant != null)
                OnAchievementGrant(achievement);
        }
    }
}
