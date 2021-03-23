using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Rigidbody playerPosition;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;

    void FixedUpdate() {
        if (playerPosition.position.y < 0.05) {
            Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
    }
}
