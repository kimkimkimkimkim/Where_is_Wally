using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingByJoystick : MonoBehaviour {

	public GameObject maincamera; //一緒に動くカメラ

	//先ほど作成したJoystick
	[SerializeField]
	private Joystick _joystick = null;

	//移動速度
	private const float SPEED = 0.2f;
	private Vector3 prevPos; //ちょい前の座標
	private Vector3 nowPos; //現在の座標

	private void Start(){
		prevPos = transform.position;
		nowPos = transform.position;
	}

	private void Update () {
		Vector3 pos = transform.position;
		Vector3 camerapos = maincamera.transform.position;
		Vector3 cameraRotation = maincamera.transform.localEulerAngles;
		Vector3 joystickPos = new Vector3(_joystick.Position.x,0,_joystick.Position.y);
		joystickPos = Quaternion.Euler (0f, cameraRotation.y, 0f) * joystickPos;

		//移動
		/*
		pos.x += _joystick.Position.x * SPEED;
		pos.z += _joystick.Position.y * SPEED;
		camerapos.x += _joystick.Position.x * SPEED;
		camerapos.z += _joystick.Position.y * SPEED;
		*/
		pos.x += joystickPos.x * SPEED;
		pos.z += joystickPos.z * SPEED;
		camerapos.x += joystickPos.x * SPEED;
		camerapos.z += joystickPos.z * SPEED;

		//方向転換
		var aim = pos - this.transform.position;
		var look = Quaternion.LookRotation(aim);
		if(joystickPos.x == 0 && joystickPos.z == 0){
			Vector3 target = maincamera.transform.forward;
			target.y = 0;
			look = Quaternion.LookRotation(target);
		}
		this.transform.localRotation = look;

		
		if(transform.position == pos){
			//移動していない
			GetComponent<Animator>().SetBool("isWalking",false);
			
		}else{
			//移動している
			GetComponent<Animator>().SetBool("isWalking",true);
		}

		transform.position = pos;
		maincamera.transform.position = camerapos;

	}


	
}
