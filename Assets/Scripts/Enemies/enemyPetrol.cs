using UnityEngine;

public class enemyPetrol : MonoBehaviour
{
    [Header("petroling points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [Header("enemy")]
    [SerializeField] private Transform enemy;
    [Header("movemet parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool moveInLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (moveInLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                moveInDirection(-1);
            }
            else
            {
                //change direction
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                moveInDirection(1);

            }
            else
            {
                //change direction
            }
        }
    }

    private void moveInDirection(int _direction)
    {
        //make him face right way
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //make him move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * speed * _direction, enemy.position.y, enemy.position.z);
    }
}
