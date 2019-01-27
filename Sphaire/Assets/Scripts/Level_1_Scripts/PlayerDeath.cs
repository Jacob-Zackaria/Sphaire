using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {
	public GameObject bloodScreen;
	private Image blood;
	public GameObject playerExplosion;
	public GameObject gameOverScreen;
	public GameObject player;
	public Slider playerHealthBar;

	private Vector3 lastCheckpoint;
	private Vector3 spawnPosition;

	private void Start() {
		spawnPosition = new Vector3(0f, 0f, 0f);
		lastCheckpoint = player.transform.position + spawnPosition;
		blood = bloodScreen.GetComponent<Image>();
	} 
	private void Update() {
		Color tempColor = blood.color;

		if(playerHealthBar.value >= 1 && player != null)	
		{
			StartCoroutine(GameOverScene());
		}
		else if(playerHealthBar.value <= 0)
		{
			playerHealthBar.value = 0;
		}
		else
		{
			playerHealthBar.value -= Time.deltaTime * 0.01f;
		}

		tempColor.a = Mathf.Clamp(playerHealthBar.value, 0, 255);
		blood.color =  tempColor;
	} 
		
	IEnumerator GameOverScene()
	{
		player.SetActive(false);
		playerHealthBar.value = 0f;
		Instantiate(playerExplosion, player.transform.position, player.transform.rotation);
		yield return new WaitForSeconds(3f);
		gameOverScreen.SetActive(true);
	}

	public void LoadCheckpoint()
	{
		player.SetActive(true);
		player.transform.position = lastCheckpoint;
		gameOverScreen.SetActive(false);
	}

	public void ChangeCheckpoint(Vector3 changeCheckpoint)
	{
		lastCheckpoint = changeCheckpoint + spawnPosition;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		SceneManager.LoadScene("LoadScreen");
	}
}
