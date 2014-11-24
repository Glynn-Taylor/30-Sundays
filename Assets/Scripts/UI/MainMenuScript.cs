using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void Quit(){
		Application.Quit ();
	}

	public void Credits(){
		OGRoot.GetInstance().GoToPage ( "Credits" );  
	}
	public void Options(){
		OGRoot.GetInstance().GoToPage ( "Options" );
	}
	public void MainMenu(){
		OGRoot.GetInstance().GoToPage ( "MainMenu" );
	}

	public void Play(){
		Application.LoadLevel("Game");
	}
}
