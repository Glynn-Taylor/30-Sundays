using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostScript : MonoBehaviour
{
    public struct Event
    {
        public string desc;
        public int weight;
        public int age;
        public Event(string d, int w){
            desc=d;
            weight=w;
            age=0;
        }
        public Event(Event e, int a){
            desc = e.desc;
            weight=e.weight;
            age=a;
        }
    }
    private Event[] events = new Event[]{
        new Event("Gave blood",10),
        new Event("Volunteered in a soup kitchen",10),
        new Event("Donated clothes to charity",4),
        new Event("Helped a friend in need",4),
        new Event("Helped an old lady cross the road",1),
        new Event("cheered up a friend",1),
        new Event("Walked the dog",1),
        new Event("Won the lottery",0),
        new Event("Enjoyed daytime tv",0),
        new Event("Poured boiling water into an anthill",-1),
        new Event("Stole sweets",-1),
        new Event("Forgot mother's birthday",-1),
        new Event("Swore at a child",-1),
        new Event("Forgot to feed pet for days",-4),
        new Event("Killed someone",-10),
        new Event("Involved in human trafficking",-10),
        new Event("Smuggled drugs",-10),
    };
    private const float Y_MOVEMENT = 3;
    private const float TIME_TO_DECAY = 7;
    private float initialY;
    private bool uiEnabled = false;
    private bool judging=false;
    private Renderer progressBarRenderer;
    private float decayTime=0;
    public List<Event> LifeEvents = new List<Event>();
    // Use this for initialization
    void Start()
    {
        initialY = transform.position.y;
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        progressBarRenderer=transform.GetChild(0).renderer;
        for(int i=0;i<3;i++){
            LifeEvents.Add(new Event(events[Random.Range(0,events.Length)],Random.Range(10,80)));
          
        }

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!uiEnabled)
        {
            transform.position += Vector3.up * Time.deltaTime;
            float yDiff = transform.position.y - initialY;
            if (yDiff < Y_MOVEMENT)
            {
                float scaleDiff = (yDiff / Y_MOVEMENT) * 0.9f;
                //transform.localScale.x= transform.localScale.y=0.1f + scaleDiff;
                transform.localScale=new Vector3(0.1f + scaleDiff, 0.1f + scaleDiff, 0.1f + scaleDiff);
            } else
            {
                uiEnabled = true;
            }
        } else if(!judging) {
            decayTime+=Time.deltaTime;
            if(decayTime>TIME_TO_DECAY){
                Destroy(gameObject);
            }else{
                progressBarRenderer.material.SetFloat("_CutOff",decayTime/TIME_TO_DECAY+0.00001f);
            }
        }
    }

    void OnMouseDown()
    {
        if (uiEnabled)
        {
            OGRoot.GetInstance().GoToPage ( "JudgementMenu" );
            OGRoot.GetInstance().currentPage.gameObject.SendMessage("SetText",this);
            judging=true;
            GameManager.Instance.setGhost(this);
            //Time.timeScale = 0;
        }
    }
    public int getJudgementScore(){
        int total =0;
        foreach(Event e in LifeEvents){
            total+=e.weight*e.age;
        }
        total=total>25?25:(total<-25?-25:total);
        return total;
    }
    public void StopJudging(){
        judging=false;
    }
}
