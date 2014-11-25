using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour
{
    private const float Y_MOVEMENT = 3;
    private const float TIME_TO_DECAY = 7;
    private float initialY;
    private bool uiEnabled = false;
    private Renderer progressBarRenderer;
    private float decayTime=0;
    // Use this for initialization
    void Start()
    {
        initialY = transform.position.y;
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        progressBarRenderer=transform.GetChild(0).renderer;

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
        } else {
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
            Time.timeScale = 0;
        }
    }
}
