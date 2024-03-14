using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1280, 720, "hejhej");
Raylib.SetTargetFPS(60);

Player player = new Player();
Rectangle playerRect = new Rectangle(player.position, player.size);
Random random = new Random();

List<Enemy> listOfEnemies = new List<Enemy> ();

while (!Raylib.WindowShouldClose()){
    playerRect.Position = player.position;

    player.movement.X = 0;
    player.movement.Y = 0;


    if (Raylib.IsKeyDown(KeyboardKey.A)){
        player.movement.X = -10;
    }
    if (Raylib.IsKeyDown(KeyboardKey.D)){
        player.movement.X = 10;
    }
    if (Raylib.IsKeyDown(KeyboardKey.W)){
        player.movement.Y = -10;
    }
    if (Raylib.IsKeyDown(KeyboardKey.S)){
        player.movement.Y = 10;
    }


    Vector2.Normalize(player.movement);
    player.position += player.movement;

    
    if (Raylib.IsKeyPressed(KeyboardKey.B)){
        Enemy enemy = new Enemy();

        enemy.Spawn(enemy, random.Next(10, 1270), random.Next(10, 710), listOfEnemies);
    }

    Raylib.BeginDrawing();

    Raylib.DrawRectangleRec(playerRect, Color.Green);


    for (int i = 0; i > listOfEnemies.Count(); i++){
        Raylib.DrawRectangleRec(listOfEnemies[i].enemyRect, Color.Red);
    }


    Raylib.ClearBackground(Color.DarkGray);
    Raylib.EndDrawing();
}
