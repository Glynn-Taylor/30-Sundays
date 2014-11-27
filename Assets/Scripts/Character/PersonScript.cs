using UnityEngine;
using System.Collections;

public class PersonScript : Humanoid {

	private const float TIME_TO_AGE = 2f;
	private float AgeTimer=0;
	public float Age = 1;
	// Use this for initialization
	void Start () {
        StartRandomized(2,3);
	}
	//Called every frame
	void Update(){
		if ((AgeTimer += Time.deltaTime) >= TIME_TO_AGE) {
			AgeTimer=0;
			Age++;
			if (Age > 16) {
                if(Random.value<Age/100f)
					GameManager.Instance.KillPerson(gameObject);
			}
		}

	}
	//FixedUpdate is called once per physics tick
	void FixedUpdate () {
        Move();
	}
	
}
