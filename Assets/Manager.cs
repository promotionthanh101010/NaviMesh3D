using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	Transform  _target;
	[SerializeField]
	GameObject refabsenemy;

	[SerializeField]
	private Transform[] _positionenemy;

	IEnumerator Craeteenemy()
	{
		float timerandom=Random.Range(2.0f,7.0f);
		yield return new WaitForSeconds(timerandom);
		createEnemy();
		StartCoroutine(Craeteenemy());
	}
	void Start () {

	StartCoroutine(Craeteenemy());
		
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void createEnemy()
	{
		int index=Random.Range(0,_positionenemy.Length);
		GameObject obj= Instantiate(refabsenemy,_positionenemy[index].position, Quaternion.identity);
		Enemy e=obj.GetComponent<Enemy>();
		if(e!=null)
			e.setTarget(_target);

	}
}
