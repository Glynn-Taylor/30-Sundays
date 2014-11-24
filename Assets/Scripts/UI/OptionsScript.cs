using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {
	public OGLabel AADisplay;
	public OGLabel QualityDisplay;
	public OGButton AnisotropicBtn;
	public OGButton TripleFilterBtn;
	// Use this for initialization
	void Start () {
		AnisotropicBtn.text=QualitySettings.anisotropicFiltering== AnisotropicFiltering.ForceEnable?"On":"Off";
		QualityDisplay.text = getQualityString ();
		AADisplay.text= QualitySettings.antiAliasing.ToString()+"x AA";
		TripleFilterBtn.text = QualitySettings.maxQueuedFrames == 0?"Off":"On";
	}
	
	public void AA(string istr){
		int i = int.Parse (istr);
		if (i == 1) {
			if( QualitySettings.antiAliasing <8)
				QualitySettings.antiAliasing +=2;
		} else {
			if( QualitySettings.antiAliasing >0)
				QualitySettings.antiAliasing -=2;
		}
		AADisplay.text= QualitySettings.antiAliasing.ToString()+"x AA";
	}
	public void SetQualityLevel(string istr){
		int i = int.Parse (istr);
		if (i == 1) {
			QualitySettings.IncreaseLevel();
		} else {
			QualitySettings.DecreaseLevel();
		}
		QualityDisplay.text = getQualityString ();
	}
	public void ToggleAnisotropic(){
		QualitySettings.anisotropicFiltering=QualitySettings.anisotropicFiltering== AnisotropicFiltering.ForceEnable?AnisotropicFiltering.Disable:AnisotropicFiltering.ForceEnable;
		AnisotropicBtn.text=QualitySettings.anisotropicFiltering== AnisotropicFiltering.ForceEnable?"On":"Off";
	}
	public void ToggleTripleBuffer(){
		QualitySettings.maxQueuedFrames = QualitySettings.maxQueuedFrames == 0?  QualitySettings.maxQueuedFrames = 3:  QualitySettings.maxQueuedFrames = 0;
		TripleFilterBtn.text = QualitySettings.maxQueuedFrames == 0?"Off":"On";
	}
	private string getQualityString(){
		switch (QualitySettings.currentLevel) 
		{
		case QualityLevel.Fastest:
			return "Fastest";
		case QualityLevel.Fast:
			return "Fast";
		case QualityLevel.Simple:
			return "Simple";
		case QualityLevel.Good:
			return "Good";
		case QualityLevel.Beautiful:
			return "Beautiful";
		case QualityLevel.Fantastic:
			return "Fantastic";
		}
		return "";
	}
}
