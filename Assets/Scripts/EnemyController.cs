using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private CharacterControllerHandler characterController;
    private AttackController attack;
    private GameObject player;
    public float speed = 10;
    public float attackRange = 5;

    private void Awake()
    {
        characterController = GetComponent<CharacterControllerHandler>();
        attack = GetComponent<AttackController>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < attackRange)
        {
            attack.Attack();
            return;
        }

        Vector3 movement = player.transform.position - transform.position;

        movement.y = 0;

        characterController.Move(movement.normalized * speed);

        Vector3 lookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(lookAt);
    }
}
