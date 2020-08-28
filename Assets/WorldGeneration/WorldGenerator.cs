using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public float gridSize = 100;
    public int objectsPerTile = 10;
    public int loadDistance = 4;
    public Transform player;
    public List<Tile> tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<Tile>();
        generateWorld();
    }

    private void generateWorld()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 originTile = calculateOriginTile(playerPos);
        Vector2 endTile = originTile + new Vector2(2*loadDistance,2*loadDistance);
        createTiles(originTile,endTile);
    }

    private Vector2 calculateOriginTile(Vector2 playerPos)
    {
        Vector2 originTile = playerPos - new Vector2(playerPos.x%gridSize,playerPos.y%gridSize);
        originTile = originTile / gridSize;
        return originTile - new Vector2(loadDistance,loadDistance);
    }

    private void createTiles(Vector2 startTile,Vector2 endTile)
    {
        for(int x = (int)startTile.x;x<endTile.x;x++)
        {
            for (int y = (int)startTile.y; y < endTile.y; y++)
            {
                Tile tile = new Tile();
                Vector2 tileLocation = new Vector2(x, y);
                tiles.Add(tile.createTile(tileLocation));
            }
        }
    }
}
