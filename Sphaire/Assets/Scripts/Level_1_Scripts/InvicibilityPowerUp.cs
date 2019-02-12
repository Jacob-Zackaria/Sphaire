using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityPowerUp : MonoBehaviour
{
    public GameObject energyExplosion;
    public float invincibilityLength;
    public PlayerDeath playerDeath;

    void Update()
    {
        //Rotate PowerUp.
        transform.Rotate(new Vector3(5, 95, 5) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //Make this Object Invincible.
            GetComponent<MeshRenderer>().enabled = false;

            //Create VFX Effects.
            Instantiate(energyExplosion, transform.position, transform.rotation);

            //Apply Invicibility.
            playerDeath.invincibilityCounter = invincibilityLength;

            //Destroy Object.
            Destroy(gameObject);
        }
    }
}
