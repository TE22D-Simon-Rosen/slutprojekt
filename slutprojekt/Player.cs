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

    //Draw the hotbar
    public void DrawHotbar(){
        Raylib.DrawRectangle(Raylib.GetScreenWidth() / 2 - 200, Raylib.GetScreenHeight() - 100, 400, 75, Color.Beige);

        for (int i = 0; i < 5; i++){ // Draws 5 slots in the hotbar
            Raylib.DrawRectangle(Raylib.GetScreenWidth() / 2 - 188 + 80 * i, Raylib.GetScreenHeight() - 90, 55, 55, Color.Blue);
        }
    }


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
