using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GameGrind
{
    public class AchievementUIList : MonoBehaviour
    {
        // Modify this to change what your achievement's score is called
        private string currencyTitle = "Points";

        [SerializeField]
        private GameObject listElementPrefab;
        [SerializeField]
        private Transform listUIPanel;
        [SerializeField]
        private Text currentAchievementScore;

        private bool isPanelActive = false;
        private List<AchievementUIElement> achievementUIObject = new List<AchievementUIElement>();

        // Use this for initialization
        void Start()
        {
            // Make sure we start at 0 score when the system is loaded
            AchievementController.CurrentAchievementScore = 0;
            gameObject.SetActive(true);
            BuildStatListUI();
            AchievementEvents.OnAchievementChange += UpdateAchievementUIData;
            AchievementEvents.OnAchievementGrant += UpdateScore;
            currentAchievementScore.text = AchievementController.CurrentAchievementScore.ToString() + " " + currencyTitle;

            // Reloading the canvas since it is a persistent object can break the prefab references so we enforce the event listener directly
            transform.Find("Close_Button").GetComponent<Button>().onClick.AddListener(() => gameObject.SetActive(false));
        }

        /// <summary>
        /// Build the List UI panel, populating it with Stat Data
        /// </summary>
        public void BuildStatListUI()
        {
            for (int i = 0; i < Journal.achievementMaster.Count; i++)
            {
                // Instantiate and set the UI element's parent to the scroll rect of our list panel
                achievementUIObject.Add(Instantiate(listElementPrefab).GetComponent<AchievementUIElement>());
                achievementUIObject[i].transform.SetParent(listUIPanel, false);
                // Shade every other row for readability
                if (i % 2 == 0)
                    achievementUIObject[i].GetComponent<Image>().color = achievementUIObject[i].altRowShading;
                if (Journal.achievementMaster[i].completed)
                    AchievementController.CurrentAchievementScore += Journal.achievementMaster[i].points;
            }
            UpdateStatListData();
        }

        /// <summary>
        /// Refresh displayed stat values.
        /// </summary>
        public void UpdateStatListData()
        {
            for (int i = 0; i < achievementUIObject.Count; i++)
            {
                achievementUIObject[i].SetAchievementValues(Journal.achievementMaster[i]);
            }
        }

        /// <summary>
        /// Refresh displayed stat values.
        /// </summary>
        public void UpdateAchievementUIData(Achievement achievement)
        {
            for (int i = 0; i < Journal.achievementMaster.Count; i++)
            {
                if (Journal.achievementMaster[i].id == achievement.id)
                    achievementUIObject[i].SetAchievementValues(achievement);
            }
        }

        /// <summary>
        /// Update the achievement list's point display
        /// </summary>
        public void UpdateScore(Achievement achievement)
        {
            currentAchievementScore.text = AchievementController.CurrentAchievementScore.ToString() + " Points";
        }

        /// <summary>
        /// Toggle the panel's active state
        /// </summary>
        public void TogglePanel()
        {
            isPanelActive = !isPanelActive;
            this.gameObject.SetActive(isPanelActive);
        }

        private void ClearAchievementList()
        {
            for (int i = 0; i < achievementUIObject.Count; i++)
            {
                Destroy(achievementUIObject[i].gameObject);
            }
        }
    }
}
