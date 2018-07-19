using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace GameGrind
{
    public class AchievementEditor : EditorWindow
    {
        private EditorAchievementHandler editorHandler;
        private Vector2 scrollStart;
        private List<bool> showAchievementDetails = new List<bool>();
        private List<Achievement> tempAchievementList = new List<Achievement>();
        [MenuItem("Window/Journal/Journal Manager")]
        static void InitializeEditor()
        {
            AchievementEditor editor = (AchievementEditor)EditorWindow.GetWindow(typeof(AchievementEditor));
            editor.maxSize = new Vector2(600, 700);
            editor.minSize = new Vector2(425, 600);
            editor.maximized = true;
            editor.titleContent = new GUIContent("Journal");
            editor.Show();

        }

        void OnGUI()
        {
            GUILayout.Space(10);
            if (GameObject.Find("JournalCanvas") == null)
            {
                EditorGUILayout.LabelField("Installation Required", EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                EditorGUILayout.LabelField("Clicking install will create the required Journal components.", EditorStyles.centeredGreyMiniLabel, GUILayout.Height(50));
                GUI.color = new Color32(76, 180, 255, 255);
                if (GUILayout.Button(new GUIContent("✔ Install Journal", "Automatically install journal's components"), GUILayout.Height(50)))
                {
                    if (GameObject.Find("JournalCanvas") == null)
                    {
                        PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>("Prefabs/JournalCanvas"));
                        Debug.Log("Journal was installed. Journal should only be installed in the first scene you want achievement tracking in as it will carry over to loaded scenes.");
                    }
                    else
                    {
                        Debug.LogWarning("An instance of Journal is already installed. To remove it, simply delete the JournalCanvas object.");
                    }
                    if (FindObjectOfType<UnityEngine.EventSystems.EventSystem>() == null)
                    {
                        Debug.Log("An EventSystem was created as one was not detected in your scene.");
                        PrefabUtility.InstantiatePrefab(Resources.Load<UnityEngine.EventSystems.EventSystem>("Prefabs/EventSystem"));
                    }
                    editorHandler.SaveFromEditor(tempAchievementList);
                    AssetDatabase.Refresh();
                }
                GUI.color = Color.white;
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.LabelField("Tools", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(new GUIContent("Undo", "Undo unsaved changes"), GUILayout.Height(35)))
            {
                editorHandler = new EditorAchievementHandler();
                tempAchievementList = new List<Achievement>(editorHandler.LoadAchievementFile());
            }
            if (GUILayout.Button(new GUIContent("0 all stats", "Reset all achievement values to 0"), GUILayout.Height(35)))
            {
                ResetAllStats();
            }
            if (GUILayout.Button(new GUIContent("Generate IDs", "Automatically generate IDs for ALL achievements, starting from 0"), GUILayout.Height(35)))
            {
                GenerateIDs();
            }
            if (GUILayout.Button(new GUIContent("Close all", "Close all open achievement editors"), GUILayout.Height(35)))
            {
                for (int i = 0; i < showAchievementDetails.Count; i++)
                {
                    showAchievementDetails[i] = false;
                }
            }
            GUI.color = new Color32(255, 145, 165, 255);
            if (GUILayout.Button(new GUIContent("Delete Player Save", "Remove the saved achievement data"), GUILayout.Height(35)))
            {
                Journal.DeleteSave();
            }
            GUI.color = Color.white;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            DrawAchievementsArea();
            DrawControlArea();
        }


        void DrawAchievementsArea()
        {
            EditorGUILayout.LabelField('\u2630' + " Achievements", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            scrollStart = EditorGUILayout.BeginScrollView(scrollStart);
            for (int i = 0; i < tempAchievementList.Count; i++)
            {
                Achievement achievement = tempAchievementList[i];
                // Grab the icon based on the saved asset path (so we can generate an instanceID for the editor)
                achievement.icon = (Sprite)AssetDatabase.LoadAssetAtPath(achievement.iconPath, typeof(Sprite));
                showAchievementDetails.Add(false);
                showAchievementDetails[i] = EditorGUILayout.Foldout(showAchievementDetails[i], achievement.title);
                if (showAchievementDetails[i])
                {

                    GUILayout.BeginVertical(EditorStyles.helpBox);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Icon", "Icon used to represent the achievement in the UI"));
                    if (achievement.iconPath != "")
                        achievement.icon = (Sprite)EditorGUILayout.ObjectField("", AssetDatabase.LoadAssetAtPath<Sprite>(achievement.iconPath), typeof(Sprite), true);
                    else
                        achievement.icon = (Sprite)EditorGUILayout.ObjectField("", achievement.icon, typeof(Sprite), true);
                    achievement.iconPath = AssetDatabase.GetAssetPath(achievement.icon);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("ID", "Unique identifier used to reference specific achievements (must be unique!)"));
                    achievement.id = EditorGUILayout.IntField(achievement.id);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Name", "Achievement's title displayed in the UI"));
                    achievement.title = EditorGUILayout.TextField(achievement.title);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Description", "Summary text displayed below the achievevement title"));
                    achievement.description = EditorGUILayout.TextArea(achievement.description);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Needed Value", "The needed incremental amount to complete achievement"));
                    achievement.neededValue = EditorGUILayout.IntField(achievement.neededValue);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Current Value", "The amount of progress currently made"));
                    achievement.value = EditorGUILayout.IntSlider(achievement.value, 0, achievement.neededValue);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Display as Percentage", "If checked, the achievement values will display as {value}%"));
                    achievement.displayAsPercentage = EditorGUILayout.Toggle(achievement.displayAsPercentage);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Reward Value", "The amount of achievement points to grant when completed"));
                    achievement.points = EditorGUILayout.IntField(achievement.points);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Completed", "Whether or not the achievement is completed"));
                    achievement.completed = EditorGUILayout.Toggle(achievement.completed);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel(new GUIContent("Secretive", "Secretive achievement details are hidden in the UI until completed"));
                    achievement.secret = EditorGUILayout.Toggle(achievement.secret);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button(new GUIContent("▲", "Move up list"), GUILayout.Width(30)) && i > 0)
                    {
                        int desiredIndex = i - 1;
                        var item = achievement;
                        tempAchievementList.RemoveAt(i);
                        tempAchievementList.Insert(desiredIndex, item);
                        showAchievementDetails[desiredIndex] = true;
                        showAchievementDetails[i] = false;
                    }
                    else if (GUILayout.Button(new GUIContent("▼", "Move down list"), GUILayout.Width(30)) && i < tempAchievementList.Count - 1)
                    {
                        int desiredIndex = i + 1;
                        var item = achievement;
                        tempAchievementList.RemoveAt(i);
                        tempAchievementList.Insert(desiredIndex, item);
                        showAchievementDetails[desiredIndex] = true;
                        showAchievementDetails[i] = false;
                    }
                    GUI.color = new Color32(255, 145, 165, 255);
                    if (GUILayout.Button(new GUIContent("✖", "Remove achievement"), GUILayout.Width(20)))
                    {
                        tempAchievementList.RemoveAt(i);
                        showAchievementDetails.RemoveAt(i);
                        ++i;

                    }
                    GUI.color = Color.white;
                    EditorGUILayout.EndHorizontal();
                    GUILayout.EndVertical();

                }
            }
            EditorGUILayout.EndScrollView();
            GUI.color = new Color32(229, 243, 255, 255);
            EditorGUILayout.EndVertical();
        }

        void DrawControlArea()
        {

            EditorGUILayout.BeginHorizontal();
            GUI.color = new Color32(76, 180, 255, 255);
            if (GUILayout.Button(new GUIContent("+ Achievement", "Create a new achievement"), GUILayout.Height(40)))
            {
                tempAchievementList.Add(new Achievement());
            }
            GUI.color = new Color32(145, 255, 205, 255);
            if (GUILayout.Button(new GUIContent("Save Changes", "Save achievement data to file"), GUILayout.Height(40)))
            {
                editorHandler.SaveFromEditor(tempAchievementList);
                AssetDatabase.Refresh();
            }
            EditorGUILayout.EndHorizontal();


        }

        void ResetAllStats()
        {
            // Set value to 0 and completed to false for each achievement
            tempAchievementList.ForEach(x =>
            {
                x.value = 0;
                x.completed = false;
            });
        }

        /// <summary>
        /// Generate IDs for all achievements, starting from 0 (this resets ALL IDS)
        /// </summary>
        void GenerateIDs()
        {
            for (int i = 0; i < tempAchievementList.Count; i++)
            {
                tempAchievementList[i].id = i;
            }
        }

        void Awake()
        {
            editorHandler = new EditorAchievementHandler();
            tempAchievementList = editorHandler.LoadAchievementFile();
        }
    }
}