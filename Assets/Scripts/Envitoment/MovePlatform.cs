using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] int Speed;

    [SerializeField] Transform EndMove;
    [SerializeField] Transform StartMove;

    private bool isEnd;

    // Update is called once per frame
    private void Start()
    {
        isEnd = false;
    }
    void Update()
    {
        Check();
        Move();   
    }

    public void Move()
    {
        if (isEnd)
        {
            
            MoveTo(StartMove);
        }
        else
        {
            MoveTo(EndMove);
        }
    }

    private void Check()
    {
        if ((Vector2.Distance(transform.position, EndMove.position) < 5.3))
        {
            isEnd = true;
        }

        if ((Vector2.Distance(transform.position, StartMove.position) < 5.3))
        {
            isEnd = false;
        }
    }

    private void MoveTo(Transform EndPosition)
    {
        if ((Vector2.Distance(transform.position, EndPosition.position) > 5))
        {
            Vector2 newPos = new Vector2(EndPosition.position.x, EndPosition.position.y);
            transform.position = Vector2.MoveTowards(transform.position, newPos, Speed * Time.deltaTime);
        }
        
        
    } 


}
