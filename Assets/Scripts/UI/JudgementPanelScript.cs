using UnityEngine;
using System.Collections;

public class JudgementPanelScript : MonoBehaviour {
    public OGLabel infoLabel;
    public OGLabel[] EventLabels;

    public void SetText(GhostScript gs){
        infoLabel.text = "Age: "+Random.Range(16,64).ToString();
        for(int i=0;i<EventLabels.Length;i++){
            if(i<gs.LifeEvents.Count)
            EventLabels[i].text="Age: "+gs.LifeEvents[i].age.ToString()+", "+gs.LifeEvents[i].desc;
        }
    }
}
