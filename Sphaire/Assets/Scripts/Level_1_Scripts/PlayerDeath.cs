using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {
	public GameObject bloodScreen;
	private Image blood;
	public GameObject playerExplosion;
	public GameObject gameOverScreen;
	public GameObject player;
	public Slider playerHealthBar;
	private void Start() {
		blood = bloodScreen.GetComponent<Image>();
	} 
	private void Update() {
		Color tempColor = blood.color;

		if(playerHealthBar.value >= 1)	
		{
			Destroy(player);
			Instantiate(playerExplosion, player.transform.position, player.transform.rotation);
			gameOverScreen.SetActive(true);
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
		
	
}
