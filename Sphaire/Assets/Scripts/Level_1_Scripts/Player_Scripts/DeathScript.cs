using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour {

	public Slider playerHealthBar;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player"))
		{
			playerHealthBar.value = 1;
		}
		else
		{
			Destroy(other.gameObject);	
		}
	}
}
