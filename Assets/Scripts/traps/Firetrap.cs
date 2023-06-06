using System.Collections;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header ("firetrap timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; //when trap is triggered when trap is activated
    private bool active; //when trap is activated and can heart the player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFireTrap());
               
          
            if (active)
                collision.GetComponent<Helth>().TakeDamage(damage);
        }
    }
    private IEnumerator ActivateFireTrap()
    {
        //triggering trap
        triggered = true;

        //Waight for delay, activate trap, turn on animation
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("activated", true);

        //waight until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        anim.SetBool("activated", false);
        active = false;
        triggered = false;
        
    }



}
