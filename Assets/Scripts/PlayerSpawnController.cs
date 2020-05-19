using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
      public GameObject go_player;

      private float radius;
      private float angleX, angleZ;
      private Vector3 player_spawn_pos;

      public Vector3 SpawnPlayer()
      {
            Vector3 pos = new Vector3(0f, 0f, 0f);

            bool spawnpoint_is_found = false;

            while(!spawnpoint_is_found)
            {
                  radius = Random.Range(0, 100f);
                  angleX = Random.Range(0, Mathf.PI * 2);
                  angleZ = Random.Range(0, Mathf.PI * 2);

                  Vector3 detector_pos = new Vector3(radius * Mathf.Cos(angleX), 200f, radius * Mathf.Sin(angleZ));

                  RaycastHit _hit;
                  if (Physics.Raycast(detector_pos, new Vector3(0, -1, 0), out _hit, 300f))
                  {
                        if(_hit.collider.tag == "Spawnable")
                        {
                              pos = new Vector3(_hit.point.x, _hit.point.y + 15f, _hit.point.z);
                              go_player.transform.position = pos;
                              spawnpoint_is_found = true;
                        }
                  }
            }

            return pos;
      }
}
