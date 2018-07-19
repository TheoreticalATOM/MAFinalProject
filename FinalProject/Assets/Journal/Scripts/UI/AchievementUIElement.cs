using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

namespace GameGrind
{
    public class AchievementUIElement : MonoBehaviour
    {
        public Text titleText, descriptionText, valueText, rewardText;
        public Slider valueSlider;
        public Image sliderFill;
        [SerializeField]
        private Image valueBackground;
        [SerializeField]
        private Image sliderBackground;
        [SerializeField]
        private Image iconImage;
        public Color progressBarCompleteColor;
        [SerializeField]
        private Color valueBackgroundColor;

        [SerializeField]
        public Color altRowShading;

        [Header("Secret Achievements Options")]
        [SerializeField]
        private Color progressBarSecretiveColor;
        [SerializeField]
        private Color secretValueBGColor;
        [SerializeField]
        private bool secretShowReward;
        [SerializeField]
        private TextAnchor secretTextAlignment;

        /// <summary>
        /// Assign the achievement UI element the appropriate achievement details
        /// </summary>
        /// <param name="achievement">The achievement assigned to this element</param>
        public void SetAchievementValues(GameGrind.Achievement achievement)
        {
            if (achievement.secret && !achievement.completed)
            {
                titleText.text = "Hidden achievement";
                descriptionText.text = "This achievement is hidden until completed";
                rewardText.text = secretShowReward ? achievement.points.ToString() : "";
                valueText.text = "";
                
                string path = achievement.iconPath.Replace("Assets/Journal/Resources/", "").Replace(".png", "").Replace(".jpeg", "");
                iconImage.sprite = Resources.Load<Sprite>(path);
                valueBackground.color = secretValueBGColor;
                descriptionText.alignment = titleText.alignment = secretTextAlignment;
                sliderFill.color = sliderBackground.color = progressBarSecretiveColor;
            }
            else if (achievement.secret && achievement.completed || !achievement.secret)
            {
                titleText.text = achievement.title;
                string path = achievement.iconPath.Replace("Assets/Journal/Resources/", "").Replace(".png", "").Replace(".jpeg", "");
                iconImage.sprite = Resources.Load<Sprite>(path);
                descriptionText.text = achievement.description;
                rewardText.text = achievement.points.ToString();
                // If the achievement is a Percentage achievement, show a percentage value in the UI
                if (achievement.displayAsPercentage)
                {
                    valueText.text = (((float)achievement.value / (float)achievement.neededValue) * 100).ToString("0.0") + "%";
                }
                // If it's not, show the standard display values "This out of that, e.g. 10/15"
                else
                {
                    valueText.text = achievement.value.ToString() + "/" + achievement.neededValue.ToString();
                }

                /*
                    Our progress bar is based 0 - 100. We calculate a percentage (which requires floats)
                    And assign the result to the progress bar
                */
                valueSlider.value = ((float)achievement.value / (float)achievement.neededValue) * 100;
                descriptionText.alignment = titleText.alignment = TextAnchor.UpperLeft;
                valueBackground.color = valueBackgroundColor;
                // If the updated achievement is completed, color the progress bar color cause yay!
                if (achievement.completed)
                    sliderFill.color = progressBarCompleteColor;
            }
        }
    }
}