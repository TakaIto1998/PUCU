using UnityEngine;

public class EnemyManager : MonoBehaviour
{
      public BoundaryManager boundaryManager;

      public GameObject enemy;
      public GameObject boss;

      public void SpawnNormal()
      {
            Vector3 pos = GenerateSpawnPosition();
            Instantiate(enemy, pos, new Quaternion(0f, 0f, 0f, 1f));
      }
      public void SpawnBoss()
      {
            Vector3 pos = GenerateSpawnPosition();
            Instantiate(boss, pos, new Quaternion(0f, 0f, 0f, 1f));
      }

      private Vector3 GenerateSpawnPosition()
      {
            Vector3 pos = new Vector3(0f, 0f, 0f);

            float radius;
            float angleX, angleZ;

            bool spawnpoint_is_found = false;

            while (!spawnpoint_is_found)
            {
                  radius = Random.Range(0, boundaryManager.radius / 2);
                  angleX = Random.Range(0, Mathf.PI * 2);
                  angleZ = Random.Range(0, Mathf.PI * 2);

                  Vector3 detector_pos = new Vector3(
                        boundaryManager.CenterOfCircle.x + radius * Mathf.Cos(angleX),
                        200f,
                        boundaryManager.CenterOfCircle.z + radius * Mathf.Sin(angleZ));

                  RaycastHit _hit;
                  if (Physics.Raycast(detector_pos, new Vector3(0, -1, 0), out _hit, 300f))
                  {
                        if (_hit.collider.tag == "Spawnable"
                              && _hit.collider.tag != "Player"
                              && _hit.collider.tag != "Enemy"
                              && _hit.collider.tag != "Boss")
                        {
                              pos = new Vector3(_hit.point.x, _hit.point.y + 10f, _hit.point.z);
                              spawnpoint_is_found = true;
                        }
                  }
            }

            return pos;
      }
}
