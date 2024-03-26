using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

class Plant1
{
    public Vector2 position = new(0,0);
    public int stage = 0;
    public Rectangle plantRect = new Rectangle(0, 0, 50, 50);

    public void DrawPlant(Plant1 target){
        Raylib.DrawRectangleRec(target.plantRect, Color.Blue);
    }
}