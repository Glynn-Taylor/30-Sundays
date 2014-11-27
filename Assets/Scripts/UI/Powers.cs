using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Powers : MonoBehaviour {
    
    protected struct Power{
        public string name;
        public string desc;
        public int cost;
        public bool isGood;

        public Power(string n,string d, int c, bool g){
            name=n;
            desc=d;
            cost=c;
            isGood=g;
        }
    }
    protected Power[] PowerList= {
        new Power("Divination","Collect all favor from heaven",10,true),
        new Power("Mating Season","Increase birth rate for 10 seconds",10,true),
        new Power("Miracle Touch","Mouse motion collects favour",10,true),
        new Power("Poodles Gate","New souls in heaven generate favour twice as fast",10,true),
        new Power("Haven","Increase heaven's capacity by 20",500,true),
        new Power("Cloud Storage","Increase heaven's capacity by 25",1000,true),
        new Power("Cloud Cluster","Increase heaven's capacity by 25",5000,true),
        new Power("Zap","Kills a random person",10,false),
        new Power("Cleansing","Collects all might from hell",10,false),
        new Power("Splintered Soul","Creates a worker to collect might",10,false),
        new Power("Hell In A Hand Basket","Increase hell's capacity by 25",10,false),
        new Power("Hells Gate","Increase hell's capacity by 25",10,false),
    };
    protected const int PADDING = 5;
    protected const int TABLE_WIDTH=500;
    protected bool Displaying;
    public Powers OtherDisplay;
    
    protected void Display(Power[] powers){
        if(Displaying){
            GUI.BeginGroup (new Rect (Screen.width/2-TABLE_WIDTH/2, Screen.height/2-(powers.Length*60)/2, TABLE_WIDTH, powers.Length*60));
            //Title label
            //Iterate through all level strings and create a button for each that starts a server with that level
            for (int i = 0; i < powers.Length; i++) {
                if (GUI.Button (new Rect (PADDING, (60 * i), TABLE_WIDTH - PADDING * 2, 50), powers[i].name+": "+powers[i].desc+" | Cost= "+powers[i].cost.ToString())){
                    
                    if(powers[i].isGood?GameManager.Instance.getFavor(powers[i].cost):GameManager.Instance.getMight(powers[i].cost)){
                        Invoke(powers[i].name.Replace(" ",""),0);
                    }
                    StopDisplaying();
                    //DEDUCT/CHECK COST
                    
                }
            }
            //End of container
            GUI.EndGroup ();
        }
    }

    public void TogglePowers(){
        Displaying=!Displaying;
        if(OtherDisplay!=null)
            OtherDisplay.StopDisplaying();
    }
    protected Power[] getEvilPowers(){
        return getAll(false);
    }
    protected Power[] getGoodPowers(){
        return getAll(true);
    }
    private Power[] getAll(bool isGood){
        List<Power> powers = new List<Power>();
        foreach(Power p in PowerList){
            if(p.isGood==isGood)
                powers.Add(p);
        }
        return powers.ToArray();
    }
    public void StopDisplaying(){
        Displaying=false;
    }
}
