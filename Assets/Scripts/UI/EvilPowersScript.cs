using UnityEngine;
using System.Collections;

public class EvilPowersScript : Powers {
    private Power[] evilPowers;
	// Use this for initialization
	void Start () {
        evilPowers=getEvilPowers();
	}
	
	void OnGUI(){
        Display(evilPowers);
    }
   
}
