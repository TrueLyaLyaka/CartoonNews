using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour 
{
    public float BulletSpeed=2f;
    private Transform BulletPos=null;
	// Use this for initialization
	void Start () {
        BulletPos=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        BulletPos.position+=BulletPos.right*BulletSpeed*Time.deltaTime;
	}
}
