using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    [SerializeField] Transform GroundCheck;
    private float groundRadius;

    [SerializeField] LayerMask WhatIsMovingPlatform;
    [SerializeField] Transform MovingPlatform;

    private void Start()
    {
        groundRadius = 0.8f;
    }

    private void Update()
    {
        MovingWithPlatform();
    }

    void MovingWithPlatform()
    {
        bool isMove;
        isMove = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, WhatIsMovingPlatform);
        if (isMove)
        {
            //transform.position = new Vector2(MovingPlatform.position.x, transform.position.y);

        }
    }

}
