using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchExplode : MonoBehaviour
{
    private Vector3 hitDirection;

    public GameObject bombExplosion;
    public PlayerController player;
    public Slider playerHealthBar;
    public float invincibilityLength;
    public PlayerDeath playerDeath;
    //private Animator anim;
    /* private void Start() {
        anim = GetComponant<Animator>();
    } */

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
             //anim.SetTrigger

//Player Knockback
            if(playerDeath.invincibilityCounter <= 0)
            {
                hitDirection = other.transform.position - transform.position;
                hitDirection = hitDirection.normalized;
                player.Knockback(hitDirection);

                if(this.CompareTag("Bomb"))
                {
                    playerHealthBar.value += 0.6f;
                }
                else if(this.CompareTag("Enemy"))
                {
                    playerHealthBar.value += 0.3f;
                }

                GetComponent<MeshRenderer>().enabled = false;
                Instantiate(bombExplosion, transform.position, transform.rotation);

                playerDeath.invincibilityCounter = invincibilityLength;

                Destroy(gameObject);
            }           
        }
    }
}
