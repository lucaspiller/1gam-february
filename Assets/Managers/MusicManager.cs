using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] tracks;
	public AudioSource player;
	
	private int currentIndex = 0;

	void Start () {
		currentIndex = Mathf.RoundToInt(Random.Range(0, tracks.Length - 1));
	}
	
	void Update () {
		if (!player.isPlaying)
		{
			currentIndex++;
			if (currentIndex > tracks.Length - 1) {
				currentIndex = 0;
			}
			
			player.clip = tracks[currentIndex];
			player.Play();
		}
	}
}
