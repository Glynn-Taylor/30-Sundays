using UnityEngine;
using System.Collections;

public class DamnedScript : HumanoidResource {
    
    void Start () {
        StartRandomized(2,3);
    }
    //Called every frame
    void Update(){
       CheckClick();
    }
    //FixedUpdate is called once per physics tick
    void FixedUpdate () {
        Move();
    }
    
    void OnMouseDown(){
        ClickHandler(true);
    }
}
