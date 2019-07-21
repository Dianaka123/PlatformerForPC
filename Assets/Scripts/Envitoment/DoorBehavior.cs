using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] GameObject DoorText;

    private Animator animator;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isOpen", isOpen);
        ActivateText();
        if (Input.GetKey(KeyCode.O) && isOpen)
        {
            // some scene
        }
    }

    private void ActivateText()
    {
        DoorText.SetActive(isOpen);
        GameObject text = DoorText.transform.Find("TextDoor").gameObject;
        text.SetActive(isOpen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
}
