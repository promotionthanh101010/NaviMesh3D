using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public enum CharacterType
	{
		enmy,
		player
	}

	[SerializeField]
	private CharacterType _type;

	[SerializeField]
	private float _force;

	[SerializeField]
	private float _forcejump;

[SerializeField]
	private float _speed; 
	[SerializeField]
	private float _speedAngle; 
	[SerializeField]
	private int _damge=2; 

	[SerializeField]
	private int  _health=5; 
	private bool _canJump=true;
	private int _maxhealth; 

	public bool _canFire=true;

	public bool _isDie=false;

	[SerializeField]
	private GameObject _refabsEffect;
	
	[SerializeField]
	private GameObject _pBullet;
	[SerializeField]
	Transform _pShot;

	IEnumerator delayforjump()
	{
		_canJump=false;
		
		 _rigitbody.AddForce(Vector3.up * _forcejump);
		yield return new WaitForSeconds(1);
		_canJump=true;

	}

	// Use this for initialization

	private Rigidbody _rigitbody;
	protected Transform _transform;
	void Start () {
		_rigitbody=GetComponent<Rigidbody>();
		_transform=this.transform;
		_maxhealth=this._health;
		selectcharacter();
	}

	public virtual void selectcharacter()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveForward()
	{
		Vector3 velo=_rigitbody.velocity;
		Vector3 v = _transform.forward * _speed*Time.deltaTime;
		v.y=velo.y;
		_rigitbody.velocity = v;
	}
	public void moveBack()
	{
		
		Vector3 velo=_rigitbody.velocity;
		Vector3 v = -_transform.forward * _speed*Time.deltaTime;
		v.y=velo.y;
		_rigitbody.velocity = v;
	}

	public void rotationLeft()
	{
		//_transform
		Vector3 r= new Vector3(0,-(_speedAngle*Time.deltaTime),0);
		_transform.Rotate(r,Space.World);

		
	}
	public void rotationRight()
	{
		//_transform
		Vector3 r= new Vector3(0,_speedAngle*Time.deltaTime,0);
		_transform.Rotate(r,Space.World);
	}
	public void Jump()
	{
		//_transform
		if(_canJump)
			StartCoroutine(delayforjump());
		
	}
	public  virtual void Hit(int damage)
	{
		//_transform
	}
	public virtual void dead()
	{
		//_transform
	}

	public virtual void fire()
	{
		//_transform
	}
	public CharacterType characterType{
		get {
			return this._type;
		}
		set {
			this._type=value;
		}
	}

public bool isPlayer()
{
	return _type==CharacterType.player;
}
public bool isEnemy()
{
	return _type==CharacterType.enmy;
}

public int UpdateHealth(int amout)
{
	this._health=amout;
	return this._health;
}
public int GetDamage()
{
	
	return this._damge;
}
public int GetPercenHealth()
{
	
	return this._health/_maxhealth;
}

public void createAffect(float time)
{
	GameObject obj=Instantiate(_refabsEffect,_transform.position,Quaternion.identity);
	Destroy(obj,3);
}
public void createBullet()
{
	if(_pBullet!=null)
	{
		GameObject obj=Instantiate(_pBullet,_pShot.position,_transform.rotation);
		Bullet  bullet=obj.GetComponent<Bullet>();	
		bullet.SetParent(this);	
	}
	else
	{
		Debug.Log("Bullet NULL");
	}
		
}
public bool IscanFire
    {
        get {return _canFire; }
        set {_canFire = value; }
    }

public bool ISDie
    {
        get {return _isDie; }
        set {_isDie = value; }
    }



}
