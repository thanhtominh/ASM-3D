using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;


    public bool attackInput;
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (!attackInput && Time.timeScale != 0)
        {
            attackInput = Input.GetMouseButtonDown(0);
        }
    }
    private void OnDisable()
    {
        horizontalInput = 0;
        verticalInput = 0;
        attackInput = false;
    }
}
