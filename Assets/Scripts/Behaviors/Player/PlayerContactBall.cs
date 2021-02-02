using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactBall : MonoBehaviour
{
    public GameState gameState;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallPrefab>())
        {
            gameState.AddScore();
            Destroy(other.gameObject);
        }
    }
}
