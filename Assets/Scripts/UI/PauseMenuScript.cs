using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
	private bool isPaused = false;
	private float MenuWidth = 200f;
	private float MenuHeight = 150f;
	
	void Update () {
		if( Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
			if(isPaused){
				Time.timeScale = 0;
			}else{
				Time.timeScale = 1;
			}
		}
	}
	
	void OnGUI()
	{
		if(isPaused)
			GUI.Window(0, new Rect(Screen.width/2-MenuWidth/2,Screen.height/2-MenuHeight/2,MenuWidth,MenuHeight), DisplayMenu, "Pause Menu");
	}
	void DisplayMenu (int i) {
		if(GUILayout.Button("Resume")){
			isPaused=false;
            Time.timeScale = 1;
		}
		if(GUILayout.Button("Main Menu")){
			Application.LoadLevel("MainMenu");
            Time.timeScale = 1;
		}
		if(GUILayout.Button("Restart")){
            Time.timeScale = 1;
			Application.LoadLevel("Game");

		}
		if(GUILayout.Button("Quit")){
			Application.Quit();
		}
	}
}
