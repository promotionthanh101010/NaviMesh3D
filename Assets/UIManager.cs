using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager instan;

	[SerializeField]
	private GameObject _uiDead;

	// Use this for initialization

	private void Awake() {
		if(instan != null && instan!=this)
		{
			Destroy(this.gameObject);
			return;
		}
		instan=this;
	}
	void Start () {
		
		_uiDead.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showDialog()
	{
		_uiDead.SetActive(true);
	}

	public void updateHealthBar(float health)
	{

	}
}
