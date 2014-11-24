using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animation))]
public class CameraScrollScript : MonoBehaviour {
	public float OverworldHeight = 14;
	public float UnderworldHeight = -14;
	private Animation LegacyAnimator;

	public void Start(){
		LegacyAnimator = gameObject.GetComponent<Animation> ();
	}
	public void ScrollUp(){
		Debug.Log ("Scrolling up: "+Time.realtimeSinceStartup.ToString());
		if (transform.position.y == UnderworldHeight) {
			LegacyAnimator.clip = animation.GetClip("CameraUnderworldUp");
			LegacyAnimator.Play();
		} else if (transform.position.y == 0) {
			LegacyAnimator.clip = animation.GetClip("CameraWorldUp");
			LegacyAnimator.Play();
		}
	}
	public void ScrollDown(){
		Debug.Log ("Scrolling down: "+Time.realtimeSinceStartup.ToString());
		if (transform.position.y == OverworldHeight) {
			LegacyAnimator.clip = animation.GetClip("CameraOverworldDown");
			LegacyAnimator.Play();
		} else if (transform.position.y == 0) {
			LegacyAnimator.clip = animation.GetClip("CameraWorldDown");
			LegacyAnimator.Play();
		}
	}
}
