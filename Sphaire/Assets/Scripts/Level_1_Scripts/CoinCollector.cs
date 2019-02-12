using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
//Variables.
    public Text coinText;

    private AudioSource coinAudio;

//Initialising.
    private void Start() {
        coinAudio = GetComponent<AudioSource>();
    }

//Add coin and play coin sound.
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            //Make this Object Invincible.
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            //Coin sound and score update.
            coinAudio.Play();
            coinText.text = "" + (int.Parse(coinText.text) + 1);
            
            //Destroy this coin.
            Destroy(gameObject, 2f);
        }
    }
}
