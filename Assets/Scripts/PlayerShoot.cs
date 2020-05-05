using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
      public Transform cameraPos;

      public ParticleSystem gunFire;

      public string weaponName = "Glock";
      public float weaponDamage = 10f;
      public float weaponRange = 100f;

      [SerializeField]
      private LayerMask mask;

      // Start is called before the first frame update
      void Start()
      {
        
      }

      // Update is called once per frame
      void Update()
      {
            if(Input.GetButtonDown("Fire1"))
            {
                  WeaponShoot();
            }
      }

      void WeaponShoot()
      {
            gunFire.Play();

            RaycastHit _hit;
            if(Physics.Raycast(cameraPos.position, cameraPos.forward, out _hit, weaponRange, mask))
            {

                  Debug.Log("we hit" + _hit.collider.name);
            }
      }
}
