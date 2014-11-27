using UnityEngine;
using System.Collections;

public class AmbientManager : MonoBehaviour {
    //Singleton instance
    private static AmbientManager instance;
	// Use this for initialization
    public AudioClip[] ambientClips;
    public AudioSource secondSource;
    public bool usingPrimarySource=true;
    
	void Start () {
	    DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(secondSource.gameObject);
        audio.Play();
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
         Debug.Log(audio.isPlaying);
	    if(usingPrimarySource&&!audio.isPlaying)
            audio.Play();
        else if(!usingPrimarySource&&!secondSource.isPlaying)
            secondSource.Play();
	}
    //Getter for singleton, handles singleton creation if non existant
    public static AmbientManager Instance
    {
        get
        {
            //Create if not existant
            if (instance == null)
            {
                instance = new GameObject ("AmbientManager").AddComponent<AmbientManager> ();
            }
            return instance;
        }
    }
    //Removal of pointer for garbage collection on quit
    public void OnApplicationQuit ()
    {
        instance = null;
    }
    public void PlayTrack(int n){
        if(usingPrimarySource){
            secondSource.clip=ambientClips[n];
            secondSource.volume=0;
            secondSource.Play();
            usingPrimarySource=false;
            StartCoroutine("ChangeMusic");
        }else{
            audio.clip=ambientClips[n];
            audio.volume=0;
            audio.Play();
            usingPrimarySource=true;
            StartCoroutine("ChangeMusic");
        }
    }
    private IEnumerator ChangeMusic()
    {
        float fTimeCounter = 0f;
        
        while(!(Mathf.Approximately(fTimeCounter, 1f)))
        {
            fTimeCounter = Mathf.Clamp01(fTimeCounter + Time.deltaTime);
            if(!usingPrimarySource){
                audio.volume = 1f - fTimeCounter;
                secondSource.volume = fTimeCounter;
            }else{
                audio.volume = fTimeCounter;
                secondSource.volume = 1f- fTimeCounter;
            }
            yield return new WaitForSeconds(0.02f);
        }
        if(usingPrimarySource)
            secondSource.Stop();
        else
            audio.Stop();
        StopCoroutine("ChangeMusic");
    }
}
