using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character {
	private NavMeshAgent _navAgent;
	private Transform _starget;

	// Use this for initialization

	public override void selectcharacter()
	{
		_navAgent=GetComponent<NavMeshAgent>();
		_navAgent.destination=_starget.transform.position;
	}

	
	// Update is called once per frame
	void Update () {

		Vector3 orinino=transform.position;
		Vector3 destiny=_starget.transform.position;
		float dis=Vector3.Distance(orinino,destiny);
		if(dis<1.5f)
		{
			_navAgent.velocity=Vector3.zero;
		}

		fire();

		
	}

	public void setTarget(Transform _starget)
	{
		this._starget=_starget;

	}
IEnumerator DelayToFire()
	{
		_canFire=false;
		this.createBullet();

		yield return new WaitForSeconds(2);

		_canFire=true;

	}
	public override void fire()
	{	
		if(_canFire)
			StartCoroutine(DelayToFire());

	}
	

	public override void Hit(int damage)
	{
		int cu=this.UpdateHealth(damage);
		if(cu<=0 && !_isDie)
			dead();

		//UI update 

		UIManager.instan.updateHealthBar(GetPercenHealth());
	}

	public override void dead()
	{
		
		this._isDie=true;
		Destroy(gameObject);

		//createAffect(3);
		
	}

}
