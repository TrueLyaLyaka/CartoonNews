using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact : MonoBehaviour 
{
    public float Damage=50f;
    public float LifeTime=2f;
    public GameObject PrtLooseBullet;
    public GameObject PrtIsGoal;


	// Use this for initialization
	void Start () 
    {
        Invoke("Die",LifeTime);
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
        {
            Debug.Log("collided "+ other.tag);
            if (PrtLooseBullet!=null)
            {
                Instantiate(PrtLooseBullet);
                PrtLooseBullet.transform.position=new Vector3(gameObject.transform.position.x,
                                                                 gameObject.transform.position.y,
                                                                 gameObject.transform.position.z);
            }
            Die();
        } 
        if (other.CompareTag("Player"))
        {
            if (PrtIsGoal!=null)
            {              
                Instantiate(PrtIsGoal);
                PrtIsGoal.transform.position=new Vector3(gameObject.transform.position.x,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z);
            }
            DriverAnimCharacter.Health-=Damage;
            Die();   
            return;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
