using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width = 20;
    public int height = 20;

    public GameObject grassTile;
    public GameObject waterTile;

    // Add these variables
    public float scale = 10f;
    private float offsetX;
    private float offsetY;

    void Start()
    {
        // Randomize map each time
        offsetX = Random.Range(0f, 1000f);
        offsetY = Random.Range(0f, 1000f);

        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = offsetX + (float)x / width * scale;
                float yCoord = offsetY + (float)y / height * scale;

                float noise = Mathf.PerlinNoise(xCoord, yCoord);

                Vector3 position = new Vector3(x, 0, y);

                if (noise < 0.3f)
                {
                    Instantiate(waterTile, position, Quaternion.identity);
                }
                else
                {
                    Instantiate(grassTile, position, Quaternion.identity);
                }
            }
        }
    }
}