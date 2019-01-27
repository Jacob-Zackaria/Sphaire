using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchExplode : MonoBehaviour
{
    public GameObject bombExplosion;
    public Slider playerHealthBar;
    //private Animator anim;
    /* private void Start() {
        anim = GetComponant<Animator>();
    } */
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //anim.SetTrigger
            playerHealthBar.value += 0.6f;
            Destroy(this.gameObject);
            Instantiate(bombExplosion, transform.position, transform.rotation);
            
        }
    }
}
