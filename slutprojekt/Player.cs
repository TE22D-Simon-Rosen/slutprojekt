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
    public Vector2 direction = new(50, 0); //Looking direction to show where the player is looking and where they can place a crop

    public void ChangeDirection(string direction, Player player){
        if (direction == "UP"){
            player.direction = new(0, -50);
        }
        else if (direction == "DOWN"){
            player.direction = new(0, 50);
        }
        else if (direction == "LEFT"){
            player.direction = new(-50, 0);
        }
        else if (direction == "RIGHT"){
            player.direction = new(50, 0);
        }
    }
}
