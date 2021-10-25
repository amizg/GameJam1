using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 2f;

    bool gameEnd = false;

    public void EndGame()
    {
        if(gameEnd == false)
        {
            gameEnd = true;
            Debug.Log("Game Over");
            FindObjectOfType<DeathMenu>().Death();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
