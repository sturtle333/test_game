using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {
    private playerMove player;
    private Transform trans;

    private float _x;
    private float _y;

    public float maxHeight;
    public float minHeight;
    public float maxWidth;
    public float minWidth;

	void Start () {
        player = FindObjectOfType<playerMove>();
        trans = GetComponent<Transform>();
    }
	
	void Update () {
        _x = player._x;
        _y = player._y + 1;
        if (_x < minWidth) _x = minWidth;
        if (_x > maxWidth) _x = maxWidth;
        if (_y > maxHeight) _y = maxHeight;
        trans.position = new Vector3(_x, _y, trans.position.z);
	}
}
