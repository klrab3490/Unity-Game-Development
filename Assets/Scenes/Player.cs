using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Vector3 moveValue;
    [SerializeField] float speed = 5f;
    [SerializeField] TextMeshProUGUI coincount;
    int collectedCoin = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Method 2 New : Move the player
        controller.Move(moveValue * Time.deltaTime * speed);
        transform.LookAt(transform.position + moveValue);
        if (moveValue.magnitude > 0.1f ) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }

        // Method 1 Old : Move the player
        // if (Input.GetKey(KeyCode.A)) {
        //     controller.Move(Vector3.left);
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     controller.Move(Vector3.right);
        // }
        // if (Input.GetKey(KeyCode.W)) {
        //     controller.Move(Vector3.forward);
        // }
        // if (Input.GetKey(KeyCode.S)) {
        //     controller.Move(Vector3.back);
        // }
    }

    void OnMove(InputValue inputValue) {
        // To Check the we get the input value
        // Debug.Log("Input Value" + inputValue.Get<Vector2>());
        
        Vector2 v = inputValue.Get<Vector2>();
        moveValue.x = v.x;
        moveValue.y = 0;
        moveValue.z = v.y;
    }

    void OnTriggerEnter(Collider collision)
    {
        // Check for collision with coins
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Player collected the coin");
            Destroy(collision.gameObject);
            collectedCoin++;
            coincount.text = collectedCoin.ToString();
        }
    }
}
