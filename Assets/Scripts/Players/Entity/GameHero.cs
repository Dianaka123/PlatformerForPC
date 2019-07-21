using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameHero : MonoBehaviour
{
    private int health;
    private Animator animator;

    public Animator Animator { get; set; }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value <= 0)
            {
                health = 0;
            }
            else if (value >= 100)
            {
                health = 100;
            }
            else
            {
                health = value;
            }
        }
    }

    

    virtual public void DeathHero()
    {
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void Attack(Collision2D hero);
   
}
