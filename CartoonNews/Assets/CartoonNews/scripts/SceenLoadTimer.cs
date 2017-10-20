using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceenLoadTimer : MonoBehaviour {
    public static float TimeDelay=5f;
    string SceeneName="Sc_TestLocation1";
	// Use this for initialization
    SceneChanger restart1;
	void Start ()
    {
        restart1 = FindObjectOfType<SceneChanger>();
       // Invoke("LoadScene",TimeDelay);
        StartCoroutine (deadTime());
	}
    void LoadScene()
    {
        Application.LoadLevel(SceeneName);
    }        
    IEnumerator deadTime()
    {
        Debug.Log("Restart in "+ TimeDelay +" sec");
        yield return new WaitForSeconds(TimeDelay);
        restart1.SceneChange();
    }
}
