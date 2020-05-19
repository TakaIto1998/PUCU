using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
      public PlayerSpawnController playerSpawnController;
      public GameObject player;

      public Vector3 CenterOfCircle;
      public float radius;
      public float shrink_speed = 1f;
      public float min_radius = 20f;

      private Vector3 player_pos;

      public PlayerHealth playerHealth;
      public float timeBetweenAttacks = 0.5f;
      private float distance_to_player;

      float timer;

      // Start is called before the first frame update
      void Start()
      {
            player = GameObject.FindGameObjectWithTag("Player");

            player_pos = playerSpawnController.SpawnPlayer();

            CenterOfCircle = player_pos;
            transform.position = CenterOfCircle;
            transform.localScale += new Vector3(radius, 0f, radius);
            distance_to_player = radius;
      }

      // Update is called once per frame
      void Update()
      {
            if(transform.localScale.x > min_radius)
            {
                  radius -= shrink_speed * Time.deltaTime;
                  transform.localScale = new Vector3(radius, 200f, radius);
            }

            timer += Time.deltaTime;

            distance_to_player = Mathf.Sqrt(
                  (player.transform.position.x - CenterOfCircle.x) * (player.transform.position.x - CenterOfCircle.x) +
                  (player.transform.position.z - CenterOfCircle.z) * (player.transform.position.z - CenterOfCircle.z));

            if((distance_to_player * 2 > radius) && (timer >= timeBetweenAttacks))
            {
                  timer = 0f;
                  if(playerHealth.currentHealth > 0)
                  {
                        playerHealth.TakeDamage(5);
                  }
            }
      }

      public void IncreaseCircleSize(float amount)
      {
            radius += amount;
      }
}
