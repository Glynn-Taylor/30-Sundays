using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager  : MonoBehaviour {
	//Singleton instance
	private static GameManager instance;
	private const float BABY_CHANCE = 6f;
	private List<GameObject> PeopleWorld = new List<GameObject>();
	private List<GameObject> PeopleUnderworld = new List<GameObject>();
	private List<GameObject> PeopleOverworld = new List<GameObject>();
	private float SecondTick = 0;
	private float WorldPopCap=50;
	private float OverworldPopCap=50;
	private float UnderworldPopCap=50;
	public OGLabel PopulationText;
	public Transform WorldPosition;

	public void Start(){
		instance = this;
		PeopleWorld.AddRange (GameObject.FindGameObjectsWithTag ("Person"));
	}

	public void KillPerson(GameObject go){
		PeopleWorld.Remove (go);
        GameObject.Instantiate(Resources.Load("ghost"),go.transform.position,go.transform.rotation);
		Destroy (go);
	}

	void CheckBirths ()
	{
		if(Random.Range(1,100)<BABY_CHANCE*PeopleWorld.Count/2){
			GameObject go = (GameObject)GameObject.Instantiate(Resources.Load ("person"));
			go.transform.position = WorldPosition.position+new Vector3(Random.Range(-2,2),0,0);
			PeopleWorld.Add (go);
			Debug.Log ("Birth!");
		}
	}

	public void Update(){
		if ((SecondTick += Time.deltaTime) >= 1) {
			CheckBirths();
			SecondTick=0;
		}
	}
	//Getter for singleton, handles singleton creation if non existant
	public static GameManager Instance
	{
		get
		{
			//Create if not existant
			if (instance == null)
			{
				instance = new GameObject ("GameManager").AddComponent<GameManager> ();
			}
			return instance;
		}
	}
	//Removal of pointer for garbage collection on quit
	public void OnApplicationQuit ()
	{
		instance = null;
	}
}
