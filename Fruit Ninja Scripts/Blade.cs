using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVel = 0.1f;
    Rigidbody2D rigid;
    private Collider2D collid;
    private Vector3 lastMouse;
    private Vector3 curMouse;
    
    // Start is called before the first frame update
    void Awake()
    {
        collid = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collid.enabled = MouseMove();
        MouseFollow();
    }

    private void MouseFollow()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rigid.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool MouseMove()
    {
        curMouse = transform.position;
        float travel = (lastMouse - curMouse).magnitude;
        lastMouse = curMouse;

        if (travel < minVel)
            return false;
        else
            return true;
    }
}
