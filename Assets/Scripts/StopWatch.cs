using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {
    public Text scoreText;
    public Text finalScoreText;
    public float timeStart = 0f;
    public float result;




    void Update() {
        timeStart += Time.deltaTime;
        scoreText.text = timeStart.ToString("F2");
    }

    public void Result() {
        result = timeStart - Time.deltaTime;
        finalScoreText.text = result.ToString("F2");
    }
}