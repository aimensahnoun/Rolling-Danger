using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private Rigidbody enemy;
    private GameObject player;
    [SerializeField] float enemySpeed = 1;

    private bool isPlayerInRange = false;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (isPlayerInRange)
        {
            Vector3 targetDirection = player.transform.position - transform.position;

            enemy.AddForce(targetDirection * enemySpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            Vector3 tempVelocity = enemy.velocity;

            tempVelocity.y = 0;

            enemy.velocity = tempVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
