using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Options")]
    public float walkingSpeed, runningSpeed;
    public float minXPosition, maxXPosition;

    [Header("Components")]
    public Rigidbody rigidbody;

    private float direction;

    void FixedUpdate()
    {
        MovePlayer();
    }

    public void UpdateInputDirection(float direction)
    {
        this.direction = direction;
    }

    // public void SetRun(bool run)
    // {
    //     this.run = run;
    // }

    private void MovePlayer()
    {

        Vector3 deltaPosition = new Vector3(direction * walkingSpeed * Time.deltaTime, 0, 0);
        if (this.transform.position.x <= minXPosition && direction < 0)
        {
            deltaPosition = Vector3.zero;
        }
        else if (this.transform.position.x > maxXPosition && direction > 0)
        {
            deltaPosition = Vector3.zero;
        }
        Debug.Log(deltaPosition);
        rigidbody.MovePosition(this.transform.position + deltaPosition);
    }
}
