using UnityEngine;
using UnityEngine.UI;

namespace GameGrind
{
    [DisallowMultipleComponent]
    public class AchievementUIPopup : MonoBehaviour
    {
        public enum AnimationType { Bounce, Ease, Fade }
        public Text popupTitleText, popupDescriptionText;
        [SerializeField]
        private Image achievementIconPopup;
        [HideInInspector]
        public Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        public void SetAchievementValues(GameGrind.Achievement achievement)
        {
            animator.Play("Achievement_Popup_Base_Animation", 0, 0f);
            string path = achievement.iconPath.Replace("Assets/Journal/Resources/", "").Replace(".png", "").Replace(".jpeg", "");
            achievementIconPopup.sprite = Resources.Load<Sprite>(path);
            popupTitleText.text = achievement.title + " completed!";
            popupDescriptionText.text = achievement.description;
        }
    }
}
