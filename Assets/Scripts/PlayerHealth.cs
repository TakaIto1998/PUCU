using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
      public int startingHealth = 100;
      public int currentHealth;
      public Slider healthSlider;
      public Image damageImage;
      public Color flashColor = new Color(1f, 0f, 0f, 0.2f);
      public float flashTime = 5f;
      public PlayerMovement playerMovement;

      bool isDead = false;
      bool damaged = false;

      // Start is called before the first frame update
      void Start()
      {
            currentHealth = startingHealth;

            playerMovement = GetComponent<PlayerMovement>();
      }

      // Update is called once per frame
      void Update()
      {
            if(damaged)
            {
                  damageImage.color = flashColor;
            }
            else
            {
                  damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashTime * Time.deltaTime);
            }
            damaged = false;
      }

      public void TakeDamage(int amount)
      {
            damaged = true;
            currentHealth -= amount;
            healthSlider.value = currentHealth;

            if (currentHealth <= 0 && !isDead)
            {
                  Death();
            }
      }

      public void Death()
      {
            isDead = true;

            playerMovement.enabled = false;
      }
}
