using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
      public PlayerHealth playerHealth;
      public EnemyHealth enemyHealth;
      public EnemyManager enemyManager;
      public BoundaryManager boundary;
      public Text stageText, enemyRemain;

      public int currentStage = 1;

      public int initialNormalEnemyNumber = 1;
      public int initialBossNumber = 0;
      public int normal_enemy_increase = 1;
      public int boss_increase = 1;

      public int initialNormalEnemyHP = 90;
      public int initialBossHP = 190;
      public int normal_enemy_hp_increase = 10;
      public int boss_hp_increase = 20;

      public float circle_increase = 20f;

      [SerializeField]
      private int currentEnemyNumber = 0;

      void Start()
      {
            StartStage(currentStage);
      }

      void Update()
      {
            stageText.text = "Stage " + currentStage;
            enemyRemain.text = "Enemy Remain: " + currentEnemyNumber;

            currentEnemyNumber =
                  GameObject.FindGameObjectsWithTag("Enemy").Length +
                  GameObject.FindGameObjectsWithTag("Boss").Length;

            if(!playerHealth.isDead)
            {
                  if(currentEnemyNumber == 0)
                  {
                        NextStage();
                  }
            }
      }

      public int NormalEnemyHP(int stageNo)
      {
            return (initialNormalEnemyHP + stageNo * normal_enemy_hp_increase);
      }

      public int BossHP(int stageNo)
      {
            return (initialBossHP + (stageNo / 5) * boss_hp_increase);
      }

      private void StartStage(int stageNo)
      {
            int number_of_normal_enemy = initialNormalEnemyNumber + stageNo * normal_enemy_increase;
            for(int i = 0; i < number_of_normal_enemy; i++)
            {
                  enemyManager.SpawnNormal();
            }

            int number_of_boss = initialBossNumber + (stageNo / 5) * boss_increase;
            for (int i = 0; i < number_of_boss; i++)
            {
                  enemyManager.SpawnBoss();
            }
      }

      private void NextStage()
      {
            currentStage++;
            boundary.IncreaseCircleSize(circle_increase);
            StartStage(currentStage);
      }

      public void GameOver()
      {
            Debug.Log("Game Over!");
      }
}
