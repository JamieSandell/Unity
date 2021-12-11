using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float normalMoveSpeed = 20f;
    [SerializeField] float slowMoveSpeed = 10f;
    [SerializeField] float steerSpeed = 300f;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = normalMoveSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, -steerAmount);
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0.0f, moveAmount, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Road")
        {
            moveSpeed = normalMoveSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Road")
        {
            moveSpeed = slowMoveSpeed;
        }
    }
}
