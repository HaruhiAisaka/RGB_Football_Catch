using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreder : MonoBehaviour
{
    public GameState gameState;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallPrefab>())
        {
            gameState.GameOver();
            Destroy(other.gameObject);
        }
    }
}
