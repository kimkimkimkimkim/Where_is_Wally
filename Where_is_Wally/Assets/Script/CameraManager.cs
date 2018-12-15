using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject targetObj; //プレイヤー
	public GameObject maincamera; //カメラ

	private Vector3 targetPos; //ターゲットの座標
	private Vector3 initPos; //最初のタップ座標
	private Vector3 prevPos; //直前の座標
	private Vector3 nowPos; //今の座標
	private float offsetBack = -2.45f; //後ろのオフセット
	private float offsetUp = 0.5f; //上のオフセット
	private int fingerCount;
/*
	private void Start(){
		//位置
		targetPos += maincamera.transform.forward * offsetBack;
		targetPos += maincamera.transform.up * offsetUp;
		maincamera.transform.position = targetPos;
		maincamera.transform.rotation = Quaternion.Euler(10.0f, 0.0f, 0.0f);
	}*/

	private void Update(){
		Debug.Log("touchCount : " + Input.touchCount);
		if(Input.touchCount == 0){
			/* 
			targetPos = targetObj.transform.position;

			//位置
			targetPos += maincamera.transform.forward * offsetBack;
			targetPos += maincamera.transform.up * offsetUp;
			maincamera.transform.position = targetPos;*/
		}
	}

	// ドラックが開始したとき呼ばれる.
    public void OnBeginDrag(PointerEventData eventData)
    {
        DragStart(eventData);
    }

    // ドラック中に呼ばれる.
    public void OnDrag(PointerEventData eventData)
    {
        Dragging(eventData);
    }

    // ドラックが終了したとき呼ばれる.
    public void OnEndDrag(PointerEventData eventData)
    {
        DragEnd(eventData);
    }

	public void DragStart(PointerEventData eventData){
		//initPos = Input.mousePosition;
		/*
		prevPos = Input.mousePosition;
		nowPos = Input.mousePosition;
		*/
		fingerCount = Input.touchCount;
		prevPos = eventData.position;
		nowPos = eventData.position;
	}

	public void Dragging(PointerEventData eventData){
		nowPos = eventData.position;
		nowPos = eventData.position;
		float deltaX = nowPos.x - prevPos.x; //x座標の差分
		float deltaY = nowPos.y - prevPos.y; //y座標の差分
		//プレイヤーの回転
		targetObj.transform.RotateAround(targetObj.transform.position, Vector3.up, deltaX * 0.2f);
		//カメラの回転
		maincamera.transform.RotateAround(targetObj.transform.position, Vector3.up, deltaX * 0.2f); //横の回転
		Vector3 cross = Vector3.Cross((targetObj.transform.position - maincamera.transform.position),Vector3.up);
		maincamera.transform.RotateAround(targetObj.transform.position, cross, deltaY * 0.2f); //横の回転
		//座標の更新
		prevPos = nowPos;
	}

	public void DragEnd(PointerEventData eventData){
		targetPos = targetObj.transform.position;

		//位置
		targetPos += maincamera.transform.forward * offsetBack;
		targetPos += maincamera.transform.up * offsetUp;
		maincamera.transform.position = targetPos;
	}

}
