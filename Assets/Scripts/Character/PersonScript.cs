using UnityEngine;
using System.Collections;

public class PersonScript : MonoBehaviour {

	private const float TIME_TO_AGE = 0.1f;
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	private float AgeTimer=0;
	public float moveSpeed = 2f;		// The speed the enemy moves at.
	public float Age = 1;
	// Use this for initialization
	void Start () {
		frontCheck = transform.GetChild (0);
		if (Random.value > 0.5f)
				Flip ();
		moveSpeed = Random.Range (2, 3);
	}
	//Called every frame
	void Update(){
		if ((AgeTimer += Time.deltaTime) >= TIME_TO_AGE) {
			AgeTimer=0;
			Age++;
			if (Age > 16) {
				if(Random.Range(0,100)<Age/100f)
					GameManager.Instance.KillPerson(gameObject);
			}
		}

	}
	//FixedUpdate is called once per physics tick
	void FixedUpdate () {
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);
		
		//Check each of the colliders.
		foreach(Collider2D c in frontHits)
		{
			//If any of the colliders is an Obstacle...
			if(c.tag == "Obstacle")
			{
				//Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
			}
		}
		//Set the enemy's velocity to moveSpeed in the x direction.
		rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, 0);	
	}
	public void Flip()
	{
		//Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
