using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadController : MonoBehaviour
{
    private Rigidbody rigid;
    private float speed = 16;
    private SnakeController snakeController;
    private float pos = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        snakeController = GetComponentInParent<SnakeController>();
    }

    //private void Update()
    //{
    //    //pos = Input.GetAxisRaw("Horizontal"); Управление для пк
    //}

    private void FixedUpdate()
    {
        MoveHead();
    }

    private void MoveHead()
    {
        if (!snakeController.FeverActive)
        {
            Vector3 newPos = new Vector3(pos, 0, 1);
            rigid.MovePosition(rigid.position + newPos * speed * Time.fixedDeltaTime);
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x = 0;
            transform.position = pos;
            rigid.MovePosition(rigid.position + Vector3.forward * speed * 3 * Time.fixedDeltaTime);
        }
    }

    public void RightButtonDown()
    {
        pos = 1;
    }

    public void LeftButtonDown()
    {
        pos = -1;
    }

    public void ButtonUp()
    {
        pos = 0;
    }
}
