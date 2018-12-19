using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour {

	private float posY;
	private float dist = 2;
	private float timeanim = 1.5f;
	// Use this for initialization
	void Start () {
		posY = this.transform.position.y;
		MoveUp();
	}
	
	private void MoveUp(){
		iTween.MoveTo(gameObject, iTween.Hash("y",posY + dist,"time",timeanim
			,"oncomplete","MoveDown","oncompletetarget",gameObject,"easetype",iTween.EaseType.easeInOutSine));
	}

	private void MoveDown(){
		iTween.MoveTo(gameObject, iTween.Hash("y",posY - dist,"time",timeanim
			,"oncomplete","MoveUp","oncompletetarget",gameObject,"easetype",iTween.EaseType.easeInOutSine));
	}



}
