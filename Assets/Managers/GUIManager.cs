using UnityEngine;

public class GUIManager : MonoBehaviour {

	public GUIText gameOverText, instructionsText, titleText, scoreText, highScoreText, musicText;
	private bool running = false;
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
		scoreText.enabled = false;
		ScoreManager.Load();
	}

	void Update () {
		if (!running) {
			if(Input.GetButtonDown("Jump")){
				GameEventManager.TriggerGameStart();
			}
		}
		scoreText.text = ScoreManager.GetScore().ToString();
		highScoreText.text = ScoreManager.GetHighScore().ToString();
	}
	
	private void GameStart () {
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		musicText.enabled = false;
		titleText.enabled = false;
		scoreText.enabled = true;
		running = true;
	}
	
	private void GameOver () {
		gameOverText.enabled = true;
		instructionsText.enabled = true;
		musicText.enabled = true;
		running = false;
		ScoreManager.Save();
	}
}