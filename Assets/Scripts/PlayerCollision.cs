using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerController controller;
    public ShuttleController shuttle;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Asteroid")
        {
            controller.isAlive = false;
            Debug.Log("Asteroid Collision");
            controller.animator.SetTrigger("Asteroid");
            controller.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collider.tag == "Shuttle" && controller.isAlive)
        {
            shuttle.animator.SetTrigger("Win");
            Debug.Log("Made it to the shuttle");
            controller.enabled = false;
            FindObjectOfType<WinMenu>().Win();
            Destroy(gameObject);
        }
    }
}