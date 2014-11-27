using UnityEngine;
using System.Collections;

public class Humanoid : MonoBehaviour {
    protected Transform frontCheck;       // Reference to the position of the gameobject used for checking if something is in front.
    public float moveSpeed = 2f;        // The speed to move at.
	
    public void Flip()
    {
        //Multiply the x component of localScale by -1.
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
    protected void Move(){
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
    protected void StartRandomized(float minSpeed, float maxSpeed){
        frontCheck = transform.GetChild (0);
        if (Random.value > 0.5f)
            Flip ();
        moveSpeed = Random.Range (minSpeed, maxSpeed);
    }
}
