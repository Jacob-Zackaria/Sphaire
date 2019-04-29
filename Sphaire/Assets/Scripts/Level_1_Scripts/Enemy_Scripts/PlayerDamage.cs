using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private Vector3 _hitDirection;
    
    public PlayerController player;
    public float invincibilityLength;
    public PlayerDeath playerDeath;
    public Slider playerHealthBar;
    public GameObject bombExplosion;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            
//Player Knockback
            if(playerDeath.invincibilityCounter <= 0)
            {
                _hitDirection = other.transform.position - transform.position;
                _hitDirection = _hitDirection.normalized;
                player.Knockback(_hitDirection);

                Handheld.Vibrate();
                playerDeath.invincibilityCounter = invincibilityLength;
//Take damage and if bomb,explode bomb.
                if (this.CompareTag("Bomb"))
                {
                    playerHealthBar.value += 0.5f;
                    
                    if(bombExplosion != null)
                    {
                        GetComponent<MeshRenderer>().enabled = false;
                        Instantiate(bombExplosion, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }
                }
                else if(this.CompareTag("Enemy"))
                {
                    playerHealthBar.value += 0.2f;
                }
    
            }           
        }
    }
}
