using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager  : MonoBehaviour {
	//Singleton instance
	private static GameManager instance;
	private const float BABY_CHANCE = 36f;
	private List<GameObject> PeopleWorld = new List<GameObject>();
	private List<GameObject> PeopleUnderworld = new List<GameObject>();
	private List<GameObject> PeopleOverworld = new List<GameObject>();
	private float SecondTick = 0;
	private float WorldPopCap=50;
	private float OverworldPopCap=50;
	private float UnderworldPopCap=50;
    private int Favor=100;
    private int Might=100;
    private GhostScript TrackedGhost;
	public OGLabel PopulationText;
    public OGLabel MightText;
    public OGLabel FavorText;
    public OGLabel GoldText;
	public Transform WorldPosition;
    public Transform[] UnderworldPositions;
    public Transform OverworldPosition;

	public void Start(){
		instance = this;
		PeopleWorld.AddRange (GameObject.FindGameObjectsWithTag ("Person"));
        PopulationText.text=PeopleWorld.Count.ToString()+"/"+WorldPopCap.ToString();
	}
    public void SendToHell(string s){
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load ("damnedsoul"));
        go.transform.position = UnderworldPositions[Random.Range(0,UnderworldPositions.Length)].position+new Vector3(Random.Range(-2,2),0,0);
        PeopleUnderworld.Add (go);
        CleanupGhost(false);
        SoundManager.Instance.Play("soul_damn");
    }
    public void SendToHeaven(string s){
        GameObject go = (GameObject)GameObject.Instantiate(Resources.Load ("blessedsoul"));
        go.transform.position = OverworldPosition.position+new Vector3(Random.Range(-2,2),0,0);
        PeopleOverworld.Add (go);
        CleanupGhost(true);
        SoundManager.Instance.Play("soul_save");
    }
   
	public void KillPerson(GameObject go){
		PeopleWorld.Remove (go);
        GameObject.Instantiate(Resources.Load("ghost"),go.transform.position,go.transform.rotation);
		Destroy (go);
	}

	void CheckBirths ()
	{
		if(PeopleWorld.Count<WorldPopCap&&Random.Range(1,100)<BABY_CHANCE*Mathf.FloorToInt(PeopleWorld.Count/2)){
			GameObject go = (GameObject)GameObject.Instantiate(Resources.Load ("person"));
			go.transform.position = WorldPosition.position+new Vector3(Random.Range(-2,2),0,0);
			PeopleWorld.Add (go);
            PopulationText.text=PeopleWorld.Count.ToString()+"/"+WorldPopCap.ToString();
			Debug.Log ("Birth!");
		}
	}

	public void Update(){
		if ((SecondTick += Time.deltaTime) >= 1) {
			CheckBirths();
			SecondTick=0;
		}
	}
    private void CleanupGhost(bool blessed){
        Destroy(TrackedGhost.gameObject);
        GameUI();
    }
    public void GameUI(){
        Time.timeScale = 1;
        OGRoot.GetInstance().GoToPage ( "Game" );
        if(TrackedGhost){
        TrackedGhost.StopJudging();
        TrackedGhost=null;
        }
    }
    public void setGhost(GhostScript go){
        TrackedGhost=go;
    }
    public bool getFavor(int amount){
        if(Favor>=amount){
            Favor-=amount;
            return true;
        }
        return false;
    }
    public bool getMight(int amount){
        if(Might>=amount){
            Might-=amount;
            return true;
        }
        return false;
    }
    public void addMight(){
        Might++;
        MightText.text=Might.ToString();
    }
    public void addFavor(){
        Favor++;
        FavorText.text=Favor.ToString();
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
