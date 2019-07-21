using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 2;
    [SerializeField] GameObject Player;
    

    private bool isFasingRight = true;


    private Animator animator;
    private Transform PlayerTransorm;


    void Start()
    {
        animator = GetComponent<Animator>();
        if (Player.GetComponent<Transform>() != null)
        {
            PlayerTransorm = Player.GetComponent<Transform>();
        }
    }

    void LateUpdate()
    {
        Moving();
    }

    void Moving()
    {
        if (PlayerTransorm != null && (Vector2.Distance(transform.position, PlayerTransorm.position) > 1 && Vector2.Distance(transform.position, PlayerTransorm.position) < 20))
        {
            animator.SetFloat("Speed", EnemySpeed);
            var distance = transform.position.x - PlayerTransorm.position.x;

            if (distance < 0 && !isFasingRight)
            {
                Flip();
            }
            else if (distance > 0 && isFasingRight)
            {
                Flip();
            }
            Vector3 newPos = new Vector2(PlayerTransorm.position.x, 0.2f);
            transform.position = Vector2.MoveTowards(transform.position, newPos, EnemySpeed * Time.deltaTime);

        }
        else
        {
            animator.SetFloat("Speed", 0.001f);
        }
    }

    private void Flip()
    {
        isFasingRight = !isFasingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
