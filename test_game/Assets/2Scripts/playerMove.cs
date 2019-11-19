using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    public float _x;
    public float _y;

    public float speed = 0.1f;
    private float _speed = 0;

    public float gravity;
    private float _gravity = 0;

    public float jumpForce;
    private float _jumpForce = 0;
    private int _flyingtime = 1;
    public bool isJump = false;
    public bool isDoubleJump = false;
    public bool isGround = false;

    private Vector3 rotLeft = new Vector3(0, 0, 0);
    private Vector3 rotRight = new Vector3(0, -180, 0);

    private Transform trans;
    private Ray ray;
    private RaycastHit2D hit;

    public LayerMask playerLayer;

	void Start () {
        trans = GetComponent<Transform>();
        ray = new Ray();
        _x = trans.position.x;
        _y = trans.position.y;

        _gravity = gravity / 50;
    }

	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) == true) _speed = speed * 2;
        else _speed = speed;

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            _x += -_speed;
            trans.rotation = Quaternion.Euler(rotLeft);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            _x += _speed;
            trans.rotation = Quaternion.Euler(rotRight);
        }
        hit = Physics2D.Raycast(trans.position, new Vector2(0, -1), 0.5f);

        if (!hit)
        {
            isGround = true;
            _flyingtime += 1;

            if (isJump == true)
            {
                if ((Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.UpArrow) == true) && !isDoubleJump)
                {
                    isDoubleJump = true;
                    _y += jumpForce;
                    _jumpForce = jumpForce;
                }

                if (Physics2D.Raycast(trans.position, new Vector2(0, 1), 0.5f))
                {
                    isJump = false;
                    return;
                }
                _jumpForce = _jumpForce >= 0 ? _jumpForce - _gravity/6 : 0;

                _y += _jumpForce/2;
            }
            _y -= _gravity;
        }
        else
        {
            isDoubleJump = false;
            isGround = true;
            _flyingtime = 0;
            _y = hit.transform.position.y + hit.transform.localScale.y / 2 + 0.5f;

            if(Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                isJump = true;
                _y += jumpForce;
                _jumpForce = jumpForce;
            }
        }

        trans.position = new Vector3((float)_x, (float)_y, trans.position.z);
	}
}
