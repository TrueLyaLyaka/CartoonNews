using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	[SerializeField] GameObject Bullet;
	public int AmmoCount=10;
	Transform ThisTransform;
	public bool ShootOn=false;
	public bool AutomaticFire=false;
	public float BulletsPerSec=0.5f;
	public float Damage=50f;
	public float BulletSpeed=2f;
	public float BulletLifeTime=2f;
	void Awake () {
		ThisTransform=GetComponent<Transform>();
	}
	void shoot () {
		if (ShootOn && AmmoCount>0) {
			GameObject thisBullet=Instantiate(Bullet,
								ThisTransform.position,
								ThisTransform.rotation) as GameObject;
			bulletImpact SetupBullet1=thisBullet.GetComponent<bulletImpact>();
			bulletMove SetupBullet2=thisBullet.GetComponent<bulletMove>();
			SetupBullet1.Damage=Damage;
			SetupBullet1.LifeTime=BulletLifeTime;
			SetupBullet2.BulletSpeed=BulletSpeed;
			AmmoCount--;
			if (AmmoCount<=0){
				AmmoCount=0;
				AutomaticFire=false;
				Debug.Log ("Ammo is finished");
			}
			ShootOn=false;
		}

	}

	IEnumerator AutomaticShoot ()
	{
		while (AmmoCount > 0) {
			ShootOn = true;
			yield return new WaitForSeconds (1 / BulletsPerSec);
			if (AmmoCount <= 0) {
				StopCoroutine (AutomaticShoot ());
			}
		}
	}

	void Update ()	{
		shoot ();	
		if (AutomaticFire) {		
			AutomaticFire=false;		
			StartCoroutine(AutomaticShoot ());
		}
	}



}
