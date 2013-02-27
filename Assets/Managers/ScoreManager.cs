using UnityEngine;

public static class ScoreManager {
	private static int score;
	private static int highScore;
	
	public static void Load() {
		highScore = PlayerPrefs.GetInt("HighScore");
	}
	
	public static void Save() {
		PlayerPrefs.SetInt("HighScore", highScore);
	}
	
	public static int GetScore() {
		return score;
	}
	
	public static int GetHighScore() {
		return highScore;
	}
	
	public static void SetDistance(float distance) {
		score = Mathf.RoundToInt(distance);
		if (score > highScore) {
			highScore = score;
		}
	}
}
