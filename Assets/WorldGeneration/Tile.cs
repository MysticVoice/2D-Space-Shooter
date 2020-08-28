using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Color c;
    public Vector2 tileLocation;

    public Tile createTile(Vector2 loc)
    {
        tileLocation = loc;
        getRandomColor();
        return this;
    }

    public void  getRandomColor()
    {
        c = new Color(Random.value,Random.value,Random.value);
    }
}
