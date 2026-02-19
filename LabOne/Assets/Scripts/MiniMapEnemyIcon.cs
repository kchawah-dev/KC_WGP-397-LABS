using UnityEngine;

public class MiniMapEnemyIcon : MonoBehaviour
{
    public Transform player;
    public Transform enemy;

    public float mapScale = 5f;

    void Update()
    {
        Vector3 offset = enemy.position - player.position;

        float x = offset.x * mapScale;
        float y = offset.z * mapScale;

        transform.localPosition = new Vector3(x, y, 0);
    }
}