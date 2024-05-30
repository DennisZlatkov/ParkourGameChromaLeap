using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Играчът, който камерата ще следи
    public Vector3 offset = new Vector3(0, 0, -10);  // Офсет от позицията на играча

    void Update()
    {
        // Обновете позицията на камерата спрямо позицията на играча
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}