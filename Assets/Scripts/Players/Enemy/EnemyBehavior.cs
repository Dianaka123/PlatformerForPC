using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : GameHero
{
    [SerializeField] GameObject Dialog;

    private bool isPlayer;

    public bool IsPlayer
    {
        get {
            return isPlayer;
        }
        set
        {
               isPlayer = value;
        }
    }
    float timer;
    const float DEFAULT_TIME_ATTAK = 0.3F;

    private void Start()
    {
        Health = 50;
        timer = DEFAULT_TIME_ATTAK;
        Animator = GetComponent<Animator>();
        Animator.SetBool("IsPlayer", isPlayer);
    }

    private void Update()
    {
        Dialog.SetActive(isPlayer);
        Animator.SetBool("IsPlayer", isPlayer);
        DeathHero();
    }

    override
    public void DeathHero()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            isPlayer = false;
            Dialog.SetActive(isPlayer);
        }
    }

    public override void Attack(Collision2D player)
    {
        var heroHalth = player.gameObject.GetComponent<PlayerBehavior>().Health;
        heroHalth -= 5;
        player.gameObject.GetComponent<PlayerBehavior>().Health = heroHalth;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            isPlayer = true;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Attack(collision);
                timer = DEFAULT_TIME_ATTAK;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
