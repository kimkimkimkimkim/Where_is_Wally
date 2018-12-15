using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject maincamera;

	private Vector3 initcameraPos;
	private Vector3 initPos;
	private Vector3 nowPos;

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
		Debug.Log("click");
		initcameraPos = maincamera.transform.position;
		initPos = eventData.position;
		nowPos = eventData.position;
	}

	public void Dragging(PointerEventData eventData){
		nowPos = eventData.position;
		nowPos = eventData.position;
		float deltaX = nowPos.x - initPos.x; //x座標の差分
		float deltaY = nowPos.y - initPos.y; //y座標の差分
		Vector3 cameraPos = initcameraPos;
		cameraPos -= new Vector3(deltaX * 0.2f,0,0);
		Vector3 front = Vector3.Cross(maincamera.transform.right,Vector3.up);
		cameraPos -= front * deltaY * 0.2f;
		//カメラの移動
		maincamera.transform.position = cameraPos;
	}

	public void DragEnd(PointerEventData eventData){

	}
}
