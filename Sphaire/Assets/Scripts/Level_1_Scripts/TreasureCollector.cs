using UnityEngine;

public class TreasureCollector : MonoBehaviour
{
    public door setKey;
    public Material greenHealth;
    public Material bluePill;

    private MeshRenderer _renderer;
    private AudioSource _audio;

    //Initialising.
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _renderer = GetComponent<MeshRenderer>();
    }

    //Add coin and play coin sound.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Make this Object Invincible.
            _renderer.enabled = false;
            GetComponent<Collider>().enabled = false;

            if (_renderer.material == greenHealth)
            {
                setKey.SetGreenKey(greenHealth);
            }
            else if (_renderer.material == bluePill)
            {
                setKey.SetBlueKey(bluePill);
            }

            //Play sound.
            _audio.Play();

            //Destroy this coin.
            Destroy(gameObject, 2f);
        }
    }
}
