using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour 
{
    public string SceneDestination="Sc_TestLocation1";
    public bool FadeOnStart=true;
    private Animator AnimatorFade=null;
    //public Vector3 TargetPosition=Vector3.zero;
    //public static Vector3 LastTarget=Vector3.zero;

    private int TriggerFadeOff=Animator.StringToHash("fadeOff");
    private int TriggerFadeOn=Animator.StringToHash("fadeOn");
	// Use this for initialization
	void Start () 
    {
        AnimatorFade=GetComponent<Animator>();
        if(FadeOnStart && AnimatorFade!=null)
            AnimatorFade.SetTrigger(TriggerFadeOff);
	}
		// Update is called once per frame
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        AnimatorFade.SetTrigger(TriggerFadeOn);
	}
    public void SceneChange()
    {
        //SceneChanger.LastTarget=TargetPosition;
        Application.LoadLevel(SceneDestination);
    }
}
