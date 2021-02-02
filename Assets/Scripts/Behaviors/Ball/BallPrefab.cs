using UnityEngine;

public class BallPrefab : MonoBehaviour
{
    public Material ballMaterial;
    private Ball ball;
    private Rigidbody rb;
    private Renderer renderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        renderer.material = ballMaterial;
    }

    public void SetBall(Ball ball)
    {
        this.ball = ball;
        renderer.material.color = ball.color;
    }

    public void Shoot(Vector3 direction)
    {
        rb.AddForce(ball.speed * direction);
    }
}