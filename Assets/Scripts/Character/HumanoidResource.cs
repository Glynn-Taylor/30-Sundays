using UnityEngine;
using System.Collections;

public class HumanoidResource : Humanoid
{
    private const float TIME_TILL_NEXT_CLICK = 5;
    public GameObject canBeClickedGraphic;
    public GameObject cantBeClickedGraphic;
    private bool canBeClicked = true;
    private float clickTimer = 0;

    protected void CheckClick()
    {
        if (!canBeClicked)
        {
            clickTimer += Time.deltaTime;
            if (clickTimer > TIME_TILL_NEXT_CLICK)
            {
                canBeClicked = true;
                canBeClickedGraphic.SetActive(true);
                cantBeClickedGraphic.SetActive(false);
                clickTimer = 0;
            }
        }
    }
    protected void ClickHandler(bool might){
        if(canBeClicked){
            if(might==true){
                GameManager.Instance.addMight();
                SoundManager.Instance.Play("soul_damn_sizzle");
            }
            else{
                GameManager.Instance.addFavor();
                SoundManager.Instance.Play("soul_giggle");
            }
            canBeClicked=false;
            canBeClickedGraphic.SetActive(false);
            cantBeClickedGraphic.SetActive(true);
        }
    }
}
