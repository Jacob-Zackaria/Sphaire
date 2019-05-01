using UnityEngine;
using System.Collections;

public class ChestDemo : MonoBehaviour {

    private Animator _chestAnim; //Animator for the chest;

    public GameObject key;
    public door theDoor;
    public GameObject explosion;

	void Start ()
    {
        //get the Animator component from the chest;
        _chestAnim = GetComponent<Animator>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine("OpenCloseChest");
        }
    }

    IEnumerator OpenCloseChest()
    {
        //play open animation;
        _chestAnim.SetTrigger("open");
        //wait 1 seconds;
        yield return new WaitForSeconds(2);
        //Instantiate Key.
        GameObject newKey = Instantiate(key, transform.position, Quaternion.Euler(45f, 0f, 0f));
        newKey.GetComponent<TreasureCollector>().setKey = theDoor;
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        _chestAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(1);
        //Destroy effects.
        Instantiate(explosion, transform.position, Quaternion.identity);
        //Destroy.
        Destroy(gameObject);
    }
}
