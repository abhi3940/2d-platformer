using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectables : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip hp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundManager.instance.PlaySound(hp);
            collision.GetComponent<Helth>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
