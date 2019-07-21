using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Writer : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private Text heroLife;
    private void Start()
    {
        heroLife = GetComponent<Text>();
    }

    private void Update()
    {
        if (Player != null)
        {
            HealthCharacter();
        }
    }

    void HealthCharacter()
    {
        int playerHealth = Player.GetComponent<PlayerBehavior>().Health;
        heroLife.text = "Health: " + playerHealth;
    }
}