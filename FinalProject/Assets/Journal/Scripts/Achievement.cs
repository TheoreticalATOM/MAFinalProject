namespace GameGrind
{
    [System.Serializable]
    public class Achievement
    {
        public int id;
        public string title;
        public UnityEngine.Sprite icon;
        public string iconPath;
        public string description;
        public int value;
        public int neededValue;
        public bool displayAsPercentage;
        public int points;
        public bool completed;
        public bool secret;
        // Construct that the JSON serializer uses to build achievement database
        public Achievement(int id, string title, UnityEngine.Sprite icon, int value, string description, int neededValue, bool displayAsPercentage, int points, bool secret, string iconPath = "")
        {
            this.id = id;
            this.title = title;
            this.iconPath = iconPath;
            if (iconPath != "")
                this.icon = UnityEngine.Resources.Load<UnityEngine.Sprite>(iconPath);
            else
                this.icon = icon;
            UnityEngine.Debug.Log(iconPath);
            this.value = value;
            this.description = description;
            this.neededValue = neededValue;
            this.displayAsPercentage = displayAsPercentage;
            this.points = points;
            this.completed = value >= neededValue;
            this.secret = secret;
        }

        // Constructor for creating new achievements, avoiding a blank canvas
        public Achievement()
        {
            this.id = Journal.achievementMaster.Count + 1;
            this.title = "New achievement";
            this.icon = null;
            this.iconPath = "";
            this.value = 0;
            this.description = "This is the description for your new achievement.";
            this.neededValue = 25;
            this.points = 10;
            this.completed = value >= neededValue;
            this.secret = false;
        }
    }

    // Wrap class used to serialize progress data to save files
    [System.Serializable]
    public class AchievementProgressData
    {
        public int id;
        public int value;
        public AchievementProgressData(int id, int value)
        {
            this.id = id;
            this.value = value;
        }
    }
}