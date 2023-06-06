using UnityEngine;

public class EnemyProjectile : EnemyDamage //will damage the player every time they touch
{
    [SerializeField] private float speed;
    [SerializeField] private float restTime;
    private float lifeTime;

    public void ActivateProjectile()
    {
        lifeTime = 0;
        gameObject.SetActive(true);

    }

    private void Update()
    {
        float movemntSpeed = speed * Time.deltaTime;
        transform.Translate(movemntSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > restTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);//exicute logic from parent script first
        gameObject.SetActive(false); // when this hits any objet deactivate
    }
}
