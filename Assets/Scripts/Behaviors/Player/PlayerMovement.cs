using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Options")]
    public float walkingSpeed, runningSpeed;
    public float minXPosition, maxXPosition;

    [Header("Components")]
    public Rigidbody rb;

    private float _direction;

    void FixedUpdate()
    {
        MovePlayer();
    }

    public void UpdateInputDirection(float direction)
    {
        this._direction = direction;
    }
    
    private void MovePlayer()
    {

        Vector3 deltaPosition = new Vector3(_direction * walkingSpeed * Time.deltaTime, 0, 0);
        if (this.transform.position.x <= minXPosition && _direction < 0)
        {
            deltaPosition = Vector3.zero;
        }
        else if (this.transform.position.x > maxXPosition && _direction > 0)
        {
            deltaPosition = Vector3.zero;
        }
        rb.MovePosition(this.transform.position + deltaPosition);
    }
}
