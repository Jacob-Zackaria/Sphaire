using UnityEngine;

public class TreasureCollector : MonoBehaviour
{
    public door setKey;
    public Material greenHealth;
    public Material bluePill;

    private MeshRenderer _renderer;
    private AudioSource _audio;
    private float _moveEndTime = 1f;

    //Initialising.
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (_moveEndTime > 0f)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up, Time.deltaTime);
        }

        if(_moveEndTime > 0f)
        {
            _moveEndTime -= Time.deltaTime;
        }
    }
    //Add coin and play coin sound.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Make this Object Invincible.
            _renderer.enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<Light>().enabled = false;

            if (_renderer.sharedMaterial == greenHealth)
            {
                setKey.SetGreenKey(greenHealth);
            }
            else if (_renderer.sharedMaterial == bluePill)
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
