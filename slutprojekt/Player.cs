using System.Drawing;
using System.Numerics;
using System.Runtime.Intrinsics;
using Raylib_cs;

class Player
{
    public int speed = 0;
    public Vector2 movement = new(0, 0);
    public Vector2 position = new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
    public Vector2 size = new(50, 50);
}
