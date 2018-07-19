// Version 1.06 (May 3rd, 2018)
// Local Getting Started Guide
// Support email:
// support@gamegrind.io
// View online guide with images:
// http://forum.gamegrind.io/d/31-journal-getting-started-guide
// Video tutorial:
// https://www.youtube.com/watch?v=Jp6NXb48BJA


!! NOTE: V1.1 changed many things in this guide. For the updated version, go to http://docs.gamegrind.io/journal

## Journal Getting Started Guide
I’m here to help you get achievements quickly set up in your game! You’ll need just a few seconds to get Journal installed, 
the rest is just making the achievments. Let’s get started.
 
### Installation
Once you have journal imported into your project, installation is as simple as clicking a menu button.
 
To do this go to `Window -> Journal -> Install Journal`. Doing this will create a new Canvas object called `JournalCanvas`.
This canvas is used specifically for Journal to position and manage UI elements. Journal also makes sure your scene has
an EventSystem object as this is required to interact with the UI. If one isn't found, the system will instantiate one.

Keep in mind that Journal is set to not be destroyed between scene loads, but no such changes are made to to EventSystem.
As a result, Journal needs to only be installed in the first scene you wish to track statistics in, but any scene
utilizing the Journal UI will need an EventSystem. Creating any UI object will automatically create one for you.
 
After simply doing that, you should be able to load the game and check out the predefined list of achievements. 
 
 **Note: Load Journal in a scene that you don't revisit during gameplay. For instance, don't install journal 
 in a level that you'll reload. Journal is set to persist between scene loads, so loading Journal during an 
 initial loading scene or even the main menu will give you the best results.**

### Creating Achievements
Installing Journal was pretty easy, yeah? Well creating achievements is just as easy! Again, go to `Window -> Journal`, and this time select `Achievement Editor`. 
This will open an editor that will allow you to modify the existing achievements, remove them, create your own, and so on. 
 
Now to add an achievement to the existing list, simply click “Add Achievement,” which will add a new achievement to the end of the list. 
By click the arrow (>), you’ll be able to fill in the achievement’s details, move it up or down in the list, or simply delete it. 
 
Each achievement consists of fields of data that you’re going to need to fill in, starting with the ID. Note, however, that all of the IDs can be automatically 
generated once you’re finished or you can just let add the IDs yourself.
 
### Achievement Details
* ID
   * Unique identifier that can be used to query for specific achievements
* Name
   * Unique identifier that can be used to query for specific achievements
   * String displayed as the achievement’s title in the UI
* Description
   * Simply a string of text detailing the achievement’s task
* Needed Value
   * Integer defining the required value to complete the achievement
* Current Value
   * A value ranging from 0 to `NeededValue` representing the achievement’s current progress
* Display as Percentage
   * Determines whether the progress will be display as “2/10” or “20%” in the UI
* Reward Value
   * The number of “points” awarded for completing this achievement
* Completed
   * Whether or not he achievement is/was completed
 
Once you have assigned your data to the achievements, you can simply click “Apply Changes” to write the data to the proper achievement file. 
Doing so will create a backup of the last used file. 
 
### The Tools
Journal comes with a few handy tools to make creating your achievements a little easier. These can be found at the top of the editor window.
 
* Reload
   * Let’s say you’re editing some achievements and you want to undo what you’ve changed. Assuming you have applied your changes, 
      you simply need to “Reload” the last saved file. This will replace your current achievements with the last used file.
* 0 All Stats
   * If you’ve been testing achievements and have given yourself starting current values, the easiest way to reset them all to 0 is to “0 All Stats”
* Delete Player Save
   * The player save file is similar to the achievement database, except the fact that the player’s file contains their completed achievement information,
      such as values, reward points, and completion. In order to add new achievements to test, or simply to reset your saves, use “Delete Player Save”.
   * This only deletes the player’s achievement data and nothing else. 
* Generate IDs
   * Generate IDs simply goes through your list of achievements, assigning appropriate IDs to each one, starting from 0. If you have Increment calls based on IDs already, doing this could break them.
* Close All
   * This simply collapses all achievement fold-outs for a smoother workflow.
 
### Implement Achievements
Journal requires a coupled approach with your code. After you’ve created your achievements, all you have to do is go through your code and call the appropriate achievements.
 
To do this, we’ll use an example achievement:
 
ID: 12,
Name: Banana Man
Description: Eat 5 bananas
NeededValue: 5
CurrentValue: 0
DisplayAsPercentage: False
RewardValue: 10
Completed: False
 
Now every time your player eats a banana, we want to increment the NeededValue of Banana Man (12). Here’s how we could do it:

````
    void EatBanana()
    {
            Eat(this.banana);
 
            // by ID
            GameGrind.Journal.Increment(12, 1);
 
            // by Name
            GameGrind.Journal.Increment("Banana Man", 1);
    }
````
Now once the player has eaten 5 bananas, the achievement will be granted and the player will earn 10 points. 
Also, instead of calling `GameGrind.Journal`, you could just include the namespace `GameGrind`. That was pretty easy, wasn’t it? 
 
### Saving Achievements
Saving data is different for every game, but Journal includes a straightforward saving solution that will work in any environment for any game. In order to save data, simply call:

````
Journal.Save();
````
 
This will write out a JSON file to the persistent data folder, depending on the platform.
 
Loading achievements is just as simple, using `Journal.Load();` you will load in the saved data, overwriting the default values. 
 
### Changing Save Location
The save location is set to the persistent data path + “/SaveData/Achievements/”. This can be changed at the very top of the Journal script file.


### Confirming Achievement is Completed
The way Journal is designed, you can easily use achievements as a content gate, much like you would questing. 
There are a couple ways of handling this, the first being a simple, straightforward conditional check:
 
````
If (Journal.GetAchievement(12).completed)
{
        Gate.Open();
}
````
You could of course do this using the achievement’s name:
 
````
If (Journal.GetAchievement(“Banana Man”).completed)
{
        Gate.Open();
}
````
The other method for handling gating content using Journal is hooking into the AchievementGranted event. You can use this to set flags throughout your game, 
or to just do something whenever specific achievements are completed.
 
````
void Start()
{
        AchievementEvents.OnAchievementGrant += OpenGate;
}
void OpenGate(Achievement achievement)
{
        // Open the gate!!
}
````
 
### Toggle Journal Panel
The UI List included in Journal includes a `TogglePanel()` method to allow you to easily activate and deactivate the panel. 
All you’ll need to do this is a reference to the AchievementUIList component that is attached to the Achievement List Panel. 


This makes it extremely easy to add toggling functionality to your already existing UI system. 

v1.03 includes a built-in keybind option for toggling the UI panel. This can be changed using the dropdown menu on the 
`JournalCanvas` component attached to the Journal canvas.


### Achievement Grant Popup
Upon completing an achievement the player will receive a popup stating which achievement was completed, achievement’s description, as well as a check mark sprite. 


This popup is always anchored to the top of the screen (included in the installation process), and upon completing an achievement, it bounces into the screen. 
To edit the popup, simply edit the Achievement_Popup object that is created, or the prefab stored in `Resources -> Prefabs`. 


### Achievement Grant Sound Effect
Upon completing an achievement, the AchievementGranter will play a sound effect. This sound clip can be easily changed by selecting the Achievement_Popup object (or the prefab), 
and adding a new clip to the `AudioSource.AudioClip`field. 


The clip added to the AudioSource will play when an achievement is completed. 


### Renaming the Achievement “Score”
The score display is dynamically calculated, as well as the score’s name. 
In order to change this to match your game, make your way to the AchievementUIList script file, and at the very top you’ll see a field called `currencyTitle`. 
Simply change this string of text to change the name of your points in the UI. 


### Progress Bar Colors
The default color for the progress bar (color before completed) can simply be changed by editing the Fill color for the `Slider` object just as you would any UI element in the Inspector. 
To do this, drag an `Achievement_Info_Container` prefab into your `Stat_Panel_Inner_Region` panel. Select the Fill Area’s child, Fill, and edit the colors there. 


In order to change the color of the fill after an achievement is completed you’ll want to select the prefab `Achievement_Info_Container`. 
This prefab contains a component called `AchievementUIElement`. On this component, you’ll see a color field for changing the color upon achievement completion.


### More to come!
That’s it for the Getting Started Guide! I hope you enjoy working with Journal throughout your game. 
I’ll be sure to get more information out regarding working with Journal, but for now you should have a complete achievement system up and running in your game.


If you have any questions, get in touch at http://forum.gamegrind.io/ or support@gamegrind.io and I’ll be sure to get back to you! Thanks again for your purchase.