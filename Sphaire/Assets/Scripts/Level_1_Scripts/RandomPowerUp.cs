using System.Collections;
using UnityEngine;

public class RandomPowerUp : MonoBehaviour
{
    public GameObject energyExplosion;
    public GameObject player;

    void Update()
    {
        //Rotate PowerUp.
        transform.Rotate(new Vector3(5, 95, 5) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //Make Object Invincible.
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            //Create VFX Effects.
            Instantiate(energyExplosion, transform.position, transform.rotation);

            //Apply Random Powers.
            StartCoroutine("SizeUp");
        }
    }

    //Size Up Power.
    IEnumerator SizeUp()
    {
        player.GetComponent<Animation>().Play("PlayerSizeUp");
        yield return new WaitForSeconds(15f);
        player.GetComponent<Animation>().Play("PlayerSizeDown");
        yield return new WaitForSeconds(2f);

        //Destroy Object.
        Destroy(gameObject);
    } 
}
