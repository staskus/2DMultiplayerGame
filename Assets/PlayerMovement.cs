﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	private Rigidbody2D m_body;
	public float Speed;
	// Use this for initialization
	void Start () {
	
		m_body = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis ("Horizontal") * Speed;
		var y = Input.GetAxis ("Vertical") * Speed;
		Move (x, y);
	}

	void Move(float x, float y) {
		m_body.velocity = new Vector2 (x, y);
	}
		
	void OnCollisionEnter2D(Collision2D coll) {

		CmdChangeColor ();
	}

	[Command]
	void CmdChangeColor() {
		
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0.5f, 0.8f), Random.Range (0.5f, 0.8f), Random.Range (0.5f, 0.8f));
	}
}
