using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {




	


	IEnumerator DelayToFire()
	{
		_canFire=false;
	
		this.createBullet();
		yield return new WaitForSeconds(1);

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
		//_transform
		_isDie=true;
		UIManager.instan.showDialog();
	}
}
