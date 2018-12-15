using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//画面サイズ
	float height = Screen.height;

	//移動と認識する最低距離
	private float disRef = 50;
	private bool canMove = true; //画面タップでプレイヤーを動かす

	private Vector3 initPos; //最初のタップ座標
	private Vector3 nowPos; //今のタップ座標
	private Rigidbody rbPlayer; //プレイヤーのリジッドボディ
	private Animator animator; //プレイヤーのアニメーター
	private float nowAngle = 0; //今の回転角
	
	// Update is called once per frame
	void Update () {
		rbPlayer = this.GetComponent<Rigidbody>();
		animator = this.GetComponent<Animator>();
		if(canMove){
			if(Input.GetMouseButtonDown(0)){
				DragStart();
			}
			if(Input.GetMouseButton(0)){
				Dragging();
			}
			if(Input.GetMouseButtonUp(0)){
				DragEnd();
			}
		}
	}

	//ドラッグ開始
	private void DragStart(){
		initPos = Input.mousePosition; //initPosに代入
	}

	//ドラッグ中
	private void Dragging(){
		nowPos = Input.mousePosition; //現在の座標を代入
		float dis = (initPos - nowPos).sqrMagnitude; //距離の二乗
		if(dis >= Mathf.Pow(disRef,2)){
			if(initPos.y >= height/2){
				//方向転換
				Turnaround();
			}else{
				//移動
				Move();
			}
		}
	}

	//ドラッグ終了
	private void DragEnd(){
		animator.SetBool("isWalking",false);
	}

	//方向転換
	private void Turnaround(){
		float k = 1; //係数
		if(initPos.x > nowPos.x)k = -1;
		nowAngle -= k * 2;
		transform.Rotate(new Vector3(0,k * 2,0));
	}

	//プレイヤーの移動
	private void Move(){
		animator.SetBool("isWalking",true);
		Vector3 direction = nowPos - initPos;
		direction = Quaternion.Euler (0f, 0f, nowAngle) * direction; //45度回転
		rbPlayer.AddForce(direction.x,0,direction.y);
	}

}
