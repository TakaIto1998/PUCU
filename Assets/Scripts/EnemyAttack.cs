using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
      public float timeBetweenAttacks = 0.5f;
      public int attackDamage = 10;

      public PlayerHealth playerHealth;

      [SerializeField]
      private GameObject player;

      bool playerInRange = false;
      float timer;

      // Start is called before the first frame update
      void Start()
      {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
      }

      private void OnTriggerEnter(Collider other)
      {
            if(other.gameObject == player)
            {
                  playerInRange = true;
            }
      }

      private void OnTriggerExit(Collider other)
      {
            if (other.gameObject == player)
            {
                  playerInRange = false;
            }
      }

      // Update is called once per frame
      void Update()
      {
            timer += Time.deltaTime;

            if(timer >= timeBetweenAttacks && playerInRange)
            {
                  Debug.Log("Attack");
                  Attack();
            }

            if(playerHealth.currentHealth <= 0)
            {
                  Debug.Log("Player is dead");
            }
      }

      private void Attack()
      {
            timer = 0f;

            if(playerHealth.currentHealth > 0)
            {
                  playerHealth.TakeDamage(attackDamage);
            }
      }
}
