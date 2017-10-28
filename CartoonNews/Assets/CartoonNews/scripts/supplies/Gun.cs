using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	[SerializeField] GameObject Bullet;
	Transform ThisTransform;
	public bool ShootOn=false;
	public bool AtomaticFire=false;
	public int BulletsPerSec=1;
	public float Damage=50f;
	public float BulletSpeed=2f;
	public float BulletLifeTime=2f;
	void Awake () {
		ThisTransform=GetComponent<Transform>();
	}
	void shoot () {
		if (ShootOn) {
			GameObject thisBullet=Instantiate(Bullet,
								ThisTransform.position,
								ThisTransform.rotation) as GameObject;
			bulletImpact SetupBullet1=thisBullet.GetComponent<bulletImpact>();
			bulletMove SetupBullet2=thisBullet.GetComponent<bulletMove>();
			SetupBullet1.Damage=Damage;
			SetupBullet1.LifeTime=BulletLifeTime;
			SetupBullet2.BulletSpeed=BulletSpeed;

			ShootOn=false;
		}
	}

	void automaticShoot ()
	{

	}

	void Update() {
		shoot();
	}



}
