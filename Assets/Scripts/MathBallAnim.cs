﻿using UnityEngine;
using System.Collections;
using TMPro;

public class MathBallAnim : MonoBehaviour 
{
	[System.Serializable]
	public class Move
	{
		public float velcity = 8.0f;
		public float velcity2 = 16.0f;
		public float animTime = 0.5f;
		public float animTime2 = 1.5f;
		public bool x_axis = false;
		public bool y_axis = false;
		public bool z_axis = false;
		public bool _direction = false;
	}
	public Move move;


	public enum eState 
	{
		Create,
		InPool, 
		ShowAnim,  
		ZoomOutAnim  
	};
	public eState _state = eState.Create;
	
	private float _elaspedTime;


	// Use this for initialization
	void Start () 
	{
		_elaspedTime = 0.0f;

	}

	public void startAnim()
	{
		_elaspedTime = 0.0f;
		_state = eState.ShowAnim;

		//GameObject _ps = _getChildGameObject("ParticleEmitter1");
		//_ps.GetComponent<ParticleSystem>().Play();
	}

	
	// Update is called once per frame
	void Update () 
	{
		if(_state == eState.ShowAnim)
		{
			//Translate-----------------------------------------------------------
			if(move.y_axis == true)
			{
				if(move._direction == false)
					transform.Translate(Vector3.up * Time.deltaTime * move.velcity);
				else
					transform.Translate(Vector3.down * Time.deltaTime * move.velcity);
			}
			
			if(move.x_axis == true)
			{
				if(move._direction == false)
					transform.Translate(Vector3.right * Time.deltaTime * move.velcity);
				else
					transform.Translate(Vector3.left * Time.deltaTime * move.velcity);
			}
			
			if(move.z_axis == true)
			{
				if(move._direction == false)
					transform.Translate(Vector3.forward * Time.deltaTime * move.velcity);
				else
					transform.Translate(Vector3.back * Time.deltaTime * move.velcity);
			}
			
			_elaspedTime += Time.deltaTime;
			if(_elaspedTime > move.animTime)
			{
				//move to animation ZoomOutAnim
				_elaspedTime = 0.0f;

				_state = eState.ZoomOutAnim;
			}
		}
		else if(_state == eState.ZoomOutAnim)
		{
			//Translate-----------------------------------------------------------
			if(move.y_axis == true)
			{
				if(move._direction == false)
					transform.Translate(Vector3.up * Time.deltaTime * move.velcity2);
				else
					transform.Translate(Vector3.down * Time.deltaTime * move.velcity2);
			}
			
			if(move.x_axis == true)
			{
				if(move._direction == false)
					transform.Translate(Vector3.right * Time.deltaTime * move.velcity2);
				else
					transform.Translate(Vector3.left * Time.deltaTime * move.velcity2);
			}
			
			if(move.z_axis == true)
			{
				if(move._direction == false)
					transform.Translate(Vector3.forward * Time.deltaTime * move.velcity2);
				else
					transform.Translate(Vector3.back * Time.deltaTime * move.velcity2);
			}
			
			_elaspedTime += Time.deltaTime;
			if(_elaspedTime > move.animTime2)
			{
				//reset animation is over
				
				_state = eState.InPool;
			}
		}

	
	}


	public void setBallRemovalColors()
	{
		GameObject image = _getChildGameObject("image1");
		image.GetComponent<Renderer>().material.color = getRandomPrimaryColor();

		GameObject _ballText = _getChildGameObject("proText");
		_ballText.GetComponent<Renderer>().material.color = getRandomPrimaryColor();

		GameObject imageHi = _getChildGameObject("hilite1");
		imageHi.GetComponent<Renderer>().material.color = getRandomPrimaryColor();
	}

	private GameObject _getChildGameObject(string withName) 
	{
		foreach (Transform child in transform)
		{
			if (child.gameObject.name == withName)
				return child.gameObject;
		}
		return null;
	}

	public void setBallText(string t)
	{
		//GameObject _ballText = _getChildGameObject("text1");
		//_ballText.GetComponent<TextMesh>().text = t;

		GameObject _ballText = _getChildGameObject("proText");
		_ballText.GetComponent<TextMeshPro>().text = t;
	}
	public void setBallTextColor(Color _c)
	{
		//GameObject _ballText = _getChildGameObject("text1");
		//_ballText.GetComponent<Renderer>().material.color = _c;

		GameObject _ballText = _getChildGameObject("proText");
		_ballText.GetComponent<Renderer>().material.color = _c;
	}

	public void setBallColor(Color _c)
	{
		GameObject image = _getChildGameObject("image1");
		image.GetComponent<Renderer>().material.color = _c;
	}
	
	public void setBallHiliteColor(Color _c)
	{
		GameObject image = _getChildGameObject("hilite1");
		image.GetComponent<Renderer>().material.color = _c;
	}
	
	public void SetBallScale (float _s) 
	{
		transform.localScale = new Vector3(_s, _s, _s);
	}
	public void SetBallAlpha (float _a) 
	{
		GameObject image = _getChildGameObject("image1");
		GameObject text = _getChildGameObject("proText");
		GameObject hilite = _getChildGameObject("hilite1");
	}		

	private Color getRandomPrimaryColor()
	{
		float rf = UnityEngine.Random.Range(0.1f, 0.9f);

		float r = 1, g = 1, b = 1;
		float dim = rf;//0.2f;
		int rn = UnityEngine.Random.Range(0, 6);
		if(rn == 0){r = dim;}
		else if(rn == 1){g = dim;}
		else if(rn == 2){b = dim;}
		else if(rn == 3){r = dim;g = dim;}
		else if(rn == 4){g = dim;b = dim;}
		else if(rn == 5){b = dim;r = dim;}

		return new Color(r, g, b, 1f);
	}

}
