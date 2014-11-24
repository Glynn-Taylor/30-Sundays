using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class BuildingScript : MonoBehaviour {
	public bool StartsBuilt = false;

	// Use this for initialization
	void Start () {
		renderer.enabled = StartsBuilt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
