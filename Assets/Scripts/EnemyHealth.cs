using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
      public StageManager stageManager;

      public int currentHealth;
      public int scoreValue = 10;

      CapsuleCollider capsuleCollider;
      bool isDead = false;

      // Start is called before the first frame update
      void Start()
      {
            GameObject ob_stageManager = GameObject.Find("StageManager");
            stageManager = ob_stageManager.GetComponent<StageManager>();

            capsuleCollider = GetComponent<CapsuleCollider>();

            if (tag == "Enemy")
            {
                  currentHealth = stageManager.NormalEnemyHP(stageManager.currentStage);
            }
            else if (tag == "Boss")
            {
                  currentHealth = stageManager.BossHP(stageManager.currentStage);
            }
            
      }

      // Update is called once per frame
      void Update()
      {

      }

      public void TakeDamage(int amount)
      {
            if (isDead) return;

            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                  Death();
            }
      }

      private void Death()
      {
            isDead = true;

            ScoreManager.score += scoreValue;
            Destroy(gameObject);
      }
}
