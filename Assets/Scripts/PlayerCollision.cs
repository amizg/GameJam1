using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Asteroid")
        {
            Debug.Log("Asteroid Collision");
            controller.animator.SetTrigger("Asteroid");
            controller.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collider.tag == "Shuttle")
        {
            Debug.Log("Made it to the shuttle");
            controller.enabled = false;
            FindObjectOfType<WinMenu>().Win();
            Destroy(gameObject);
        }
    }

}