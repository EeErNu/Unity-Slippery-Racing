using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public StopWatch stopWatch;
    void OnTriggerEnter() {
        gameManager.CompleteLevel();
        stopWatch.Result();
    }
}
