using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1280, 720, "hejhej");
Raylib.SetTargetFPS(60);

Player player = new Player();
Rectangle playerRect = new Rectangle(player.position, player.size);
Rectangle playerReach = new Rectangle(player.direction, player.size);
Random random = new Random();

Color transparentGreen = new Color(108, 224, 79, 100);
Color transparentRed = new Color(237, 12, 12, 150);
List<Plants> listOfPlants = new List<Plants>();

Plants testPlant = new Plants();
listOfPlants.Add(testPlant);

Game game = new Game();


while (!Raylib.WindowShouldClose())
{
    if (game.scene == "game"){
        playerRect.Position = player.position;
        playerReach.Position = player.position + player.direction;

        if (Raylib.IsKeyPressed(KeyboardKey.A))
        {
            player.position.X -= 50;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.D))
        {
            player.position.X += 50;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.W))
        {
            player.position.Y -= 50;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.S))
        {
            player.position.Y += 50;
        }


        if (Raylib.IsKeyPressed(KeyboardKey.Up))
        {
            player.ChangeDirection("UP", player);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Down))
        {
            player.ChangeDirection("DOWN", player);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Left))
        {
            player.ChangeDirection("LEFT", player);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Right))
        {
            player.ChangeDirection("RIGHT", player);
        }


        if (Raylib.IsKeyPressed(KeyboardKey.One))
        {
            player.selectedPlant = 1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Two))
        {
            player.selectedPlant = 2;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Three))
        {
            player.selectedPlant = 3;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Four))
        {
            player.selectedPlant = 4;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Five))
        {
            player.selectedPlant = 5;
        }


        if (Raylib.IsKeyReleased(KeyboardKey.M))
        {
            if (player.selectedPlant != 1)
            {
                Plants plant = new Plants();
                plant.PlacePlant(plant, player, listOfPlants);
            }
            else
            {
                player.RemovePlant(listOfPlants, player);
            }
        }


        Raylib.BeginDrawing();


        foreach (Plants plant in listOfPlants)
        {
            plant.DrawPlant(plant);
        }


        game.DrawBed(); // Draws the bed in the top-left corner of the screen


        Raylib.DrawRectangleRec(playerRect, Color.Green); // Draws player

        if (player.selectedPlant == 1)
        {
            Raylib.DrawRectangleRec(playerReach, transparentRed); // If remove is selected in hotbar the square will be red
        }
        else
        {
            Raylib.DrawRectangleRec(playerReach, transparentGreen);
        }


        player.DrawHUD();

        if (Raylib.IsKeyPressed(KeyboardKey.E))
        {
            if (Raylib.CheckCollisionRecs(playerRect, game.bed)){
                game.EndDay(playerRect, listOfPlants);
                game.timer = 0;
                game.scene = "sleep";
            }
        }

        Console.WriteLine(string.Join(", ", listOfPlants));
    }


    else if (game.scene == "sleep"){
        game.Sleep();
    }


    Raylib.ClearBackground(Color.DarkGreen);
    Raylib.EndDrawing();
}
