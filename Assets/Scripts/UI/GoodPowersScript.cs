using UnityEngine;
using System.Collections;

public class GoodPowersScript  : Powers {
    private Power[] goodPowers;
    // Use this for initialization
    void Start () {
        goodPowers=getGoodPowers();
    }
    
    void OnGUI(){
        Display(goodPowers);
    }
    
}
