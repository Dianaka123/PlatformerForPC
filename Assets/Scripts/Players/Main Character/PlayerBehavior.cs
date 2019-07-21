using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehavior : GameHero
{
    private bool isFight;
    [SerializeField] string nameMenuScene;
    private void Start()
    {
        isFight = false;
        Health = 100;
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        DeathHero();
        Animator.SetBool("isEnemy", isFight);
    }

    private void FixedUpdate()
    {
        Fait();
    }

    private void OnCollisionStay2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            Attack(enemy);
        }
    }

    private void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            isFight = false;
        }
    }

    public override void Attack(Collision2D enemy)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFight = true;
            int enemyHealth = enemy.gameObject.GetComponent<EnemyBehavior>().Health;
            enemyHealth -= 10;
            enemy.gameObject.GetComponent<EnemyBehavior>().Health = enemyHealth;
        }
    }
    void Fait()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFight = true;
        }
        else 
        {
            isFight = false;
        }
    }

}
