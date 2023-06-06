using UnityEngine;

public class Spikehead : EnemyDamage
{
    [Header("SpikeHead attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;



    private float cheakTimer;
    private bool attacking;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            cheakTimer += Time.deltaTime;
            if (cheakTimer > checkDelay)
                CheckForPlayer();
                    
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirectons();
        //cheak if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                cheakTimer = 0;
            }
        }
    }

    private void CalculateDirectons()
    {
        directions[0] = transform.right * range; //Right direction
        directions[1] = -transform.right * range; //left direction
        directions[2] = transform.up * range; //up direction
        directions[3] = -transform.up * range; //down direction
    }

    private void Stop()
    {
        destination = transform.position; //Set direction as current position so that it dosen't move
        attacking = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        soundManager.instance.PlaySound(impactSound);
        base.OnTriggerEnter2D(collision);
        //stops when spikehead hit something
        Stop();

    }
}

