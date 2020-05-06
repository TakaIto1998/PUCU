using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
      public PlayerHealth playerHealth;
      public GameObject enemy;
      public Transform spawmPoint;

      // Start is called before the first frame update
      void Start()
      {
            Spawn();
      }

      // Update is called once per frame
      void Update()
      {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                  Spawn();
            }
      }

      void Spawn()
      {
            Instantiate(enemy, spawmPoint.position, spawmPoint.rotation);
      }
}
