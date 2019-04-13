using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {
//Variables.
	public GameObject bloodScreen;
	private Image blood;
	public GameObject playerExplosion;
	public GameObject gameOverScreen;
	public GameObject player;
	public Slider playerHealthBar;
	[HideInInspector]
	public float invincibilityCounter;

	private Vector3 lastCheckpoint;
	private Renderer playerRenderer;

//Initialising Values.
	private void Start() {
		playerRenderer = player.GetComponent<MeshRenderer>();
		lastCheckpoint = player.transform.position;
		blood = bloodScreen.GetComponent<Image>();
	} 

//Player Blood screen and invicibility status.
	private void Update() {
		if(invincibilityCounter > 0)
		{
			invincibilityCounter -= Time.deltaTime;
			playerRenderer.enabled = !playerRenderer.enabled;
		}

		if(invincibilityCounter < 0)
		{
			playerRenderer.enabled = true;
		}
		
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

//Coroutine to wait for player explosion.		
	IEnumerator GameOverScene()
	{
		player.SetActive(false);
		playerHealthBar.value = 0f;
		Instantiate(playerExplosion, player.transform.position, player.transform.rotation);
		yield return new WaitForSeconds(3f);
		gameOverScreen.SetActive(true);
	}

//Load last checkpoint.
	public void LoadCheckpoint()
	{
		player.SetActive(true);
		player.transform.position = lastCheckpoint;
		gameOverScreen.SetActive(false);
	}

//Create new checkpoint.
	public void ChangeCheckpoint(Vector3 changeCheckpoint)
	{
		lastCheckpoint = changeCheckpoint;
	}

//Restart level.
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

//Exit to main menu.
	public void ExitGame()
	{
		SceneManager.LoadScene("LoadScreen");
	}
}
