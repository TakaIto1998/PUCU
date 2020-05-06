using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
      //public Camera camera;
      public Transform cameraPos;

      public ParticleSystem gunFire;
      public GameObject impactSpark;

      public string weaponName = "Glock";
      public int weaponDamage = 20;
      public float weaponRange = 100f;
      public float timeBetweenBullets = 0.3f;

      private float timer;
      [SerializeField]
      private LayerMask mask;

      // Start is called before the first frame update
      void Start()
      {
        
      }

      // Update is called once per frame
      void Update()
      {
            timer += Time.deltaTime;

            if(Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets)
            {
                  WeaponShoot();
            }
      }

      void WeaponShoot()
      {
            timer = 0f;

            gunFire.Stop();
            gunFire.Play();

            RaycastHit _hit;
            if(Physics.Raycast(cameraPos.position, cameraPos.forward, out _hit, weaponRange, mask))
            {
                  GameObject impactGO = Instantiate(impactSpark, _hit.point, Quaternion.LookRotation(_hit.normal));
                  Destroy(impactGO, 1f); // Destory impactSpark prefab after 1s

                  if(_hit.collider.tag == "Enemy")
                  {
                        EnemyHealth enemyHealth = _hit.collider.GetComponent<EnemyHealth>();
                        if(enemyHealth != null)
                        {
                              enemyHealth.TakeDamage(weaponDamage);
                        }
                  }
            }
      }
}
