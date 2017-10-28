using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
    
public class DriverAnimCharacter : MonoBehaviour 
{
    public Lib.namePersonCharacters namePerson;
    private Animator takeAnimator = null;
    public string tagUnit;


    #region Health   
    public static float Health
    {
        get
        {
            return _Health;
        }
        set
        {
            _Health = value;
            if (_Health<=0)
            {
                _Health = 0;
                Debug.Log("that obsolate mode to load a new sceen");
            }           
        }
    }
    private static float _Health = 100f;
    #endregion


    void Die()
    {
        Debug.Log(gameObject.name + " was die");
        takeAnimator.SetTrigger("dead");
        gameObject.tag=Lib.UseTag(Lib.UTags.dead);
    }
	// Use this for initialization
	void Start() 
    {		
        takeAnimator = GetComponentInChildren<Animator>();
        Health=100f;
        takeAnimator.SetTrigger("jump");
	}
    #region For animations event



    #endregion
    // Update is called once per frame
	void FixedUpdate () 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Health=0;
        }
        if (Health<=0 && gameObject.tag==Lib.UseTag(Lib.UTags.Player)) Die();
	}    
}
