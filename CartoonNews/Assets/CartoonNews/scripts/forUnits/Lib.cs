using UnityEngine;
using System.Collections;
// case all unit datas
// 

public class Lib : MonoBehaviour
{
    public enum namePersonCharacters {Huilo, Cat, OldWoman};// characters

    #region Base States for units
    public enum nameParametersInAnimator {walk, run, jump, die}; // States 

    public enum UTags{dead, Player, UnitNeutrall, enemy};

    public UTags StateTag=UTags.dead;

    #endregion

    public static string UseTag(UTags StateTag)
    {
        switch (StateTag)
        {
            case (UTags.dead):return "dead";break; 
            case (UTags.Player):return "Player";break; 
            case (UTags.enemy):return "Enemy";break; 
                
            default: return "enemy"; break;               
        }
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log("it dont plase be here");
	}
}
/*
Бабка - 
алкаш - 
пионер -
кот -

*/