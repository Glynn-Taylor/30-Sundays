using UnityEngine;
using System.Collections;

public class BlessedScript : Humanoid {
    void Start () {
        StartRandomized(2,3);
    }
    //Called every frame
    void Update(){
        
    }
    //FixedUpdate is called once per physics tick
    void FixedUpdate () {
        Move();
    }
}
