using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1280, 720, "hejhej");
Raylib.SetTargetFPS(60);

Player player = new Player();
Rectangle playerRect = new Rectangle(player.position, player.size);
Rectangle playerReach = new Rectangle(player.direction, player.size);
Random random = new Random();

Color transparentGreen = new Color(108, 224, 79, 100);
List<object> plants = new List<object>();


while (!Raylib.WindowShouldClose()){
    playerRect.Position = player.position;
    playerReach.Position = player.position + player.direction;


    if (Raylib.IsKeyPressed(KeyboardKey.A)){
        player.position.X -= 50;
    }
    if (Raylib.IsKeyPressed(KeyboardKey.D)){
        player.position.X += 50;
    }
    if (Raylib.IsKeyPressed(KeyboardKey.W)){
        player.position.Y -= 50;
    }
    if (Raylib.IsKeyPressed(KeyboardKey.S)){
        player.position.Y += 50;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.Up)){
        player.ChangeDirection("UP", player);
    }
    if (Raylib.IsKeyPressed(KeyboardKey.Down)){
        player.ChangeDirection("DOWN", player);
    }
    if (Raylib.IsKeyPressed(KeyboardKey.Left)){
        player.ChangeDirection("LEFT", player);
    }
    if (Raylib.IsKeyPressed(KeyboardKey.Right)){
        player.ChangeDirection("RIGHT", player);
    }


    if (Raylib.IsKeyPressed(KeyboardKey.C)){
        Plant1 plant = new Plant1();
        plant.position = player.position + player.direction;
        plant.plantRect.X = (int)plant.position.X;
        plant.plantRect.Y = (int)plant.position.Y;

        plants.Add(plant);
    }


    Raylib.BeginDrawing();

    Raylib.DrawRectangleRec(playerRect, Color.Green);
    Raylib.DrawRectangleRec(playerReach, transparentGreen);

    foreach (Plant1 plant in plants){
        plant.DrawPlant(plant);
    }

    Raylib.ClearBackground(Color.DarkGray);
    Raylib.EndDrawing();
}
