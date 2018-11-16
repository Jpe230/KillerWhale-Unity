using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour {

    RectTransform rectTranform;
    private Vector3 mousePosition;
    public Transform nextPos;
    public float moveSpeed = .1f;


    public bool isFirst = false;


	void Update () {
        if (isFirst)
        {
            mousePosition = Input.mousePosition;
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, nextPos.position, moveSpeed);
        }
       
    }
}
