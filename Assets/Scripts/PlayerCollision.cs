using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerController controller;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Asteroid")
        {
            Debug.Log("Asteroid Collision");

            controller.enabled = false;
            
            
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }

}