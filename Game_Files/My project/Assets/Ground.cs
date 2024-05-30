using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    public GameObject groundTilePrefab; // The ground tile prefab
    public int numberOfTiles = 10; // Number of tiles to duplicate
    public float tileWidth = 1f; // Width of each tile

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject newTile = Instantiate(groundTilePrefab, transform);
            newTile.transform.position = new Vector3(i * tileWidth, transform.position.y, transform.position.z);
        }
    }
}