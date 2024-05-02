using System.Formats.Asn1;
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
// Is a list becuase it has to be dynamically changed when placing plants which an array can't do

Plants testPlant = new Plants();
listOfPlants.Add(testPlant);

Game game = new Game();



while (!Raylib.WindowShouldClose())
{
    if (game.scene == "start")
    {
        Raylib.DrawText("cool game", Raylib.GetScreenWidth() / 2 - 225, Raylib.GetScreenHeight() / 2 - 150, 100, Color.Blue);
        Raylib.DrawText("Press space to start", Raylib.GetScreenWidth() / 2 - 220, 500, 40, Color.White);
        Raylib.DrawText("Press E to view how to play", Raylib.GetScreenWidth() / 2 - 190, 600, 40, Color.White);

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            game.scene = "game";
        }
        if (Raylib.IsKeyPressed(KeyboardKey.E)){
            game.scene = "tutorial";
        }
    }
    else if (game.scene == "tutorial"){
        game.ShowTutorial();
        if (Raylib.IsKeyPressed(KeyboardKey.E)){
            game.scene = "start";
        }
    }
    else if (game.scene == "game")
    {
        playerRect.Position = player.position;
        playerReach.Position = player.position + player.direction;

        // Player movement
        player.Movement(player);

        // Changes which direction the player is looking
        player.ChangeDirection(player);

        // Changes the selected item in the hotbar
        player.SelectPlant(player);

        // Place or remove plant when pressing M
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
            if (Raylib.CheckCollisionRecs(playerRect, game.bed))
            {
                game.EndDay(listOfPlants, player);
                player.money = game.AddValuesAndMultiplyBy3(player.money, player.inventory);
                player.inventory = 0;
                game.timer = 0;
                game.scene = "sleep";
            }
        }

        Console.WriteLine(string.Join(", ", listOfPlants));
    }
    else if (game.scene == "sleep")
    {
        game.Sleep();
    }


    Raylib.ClearBackground(Color.DarkGreen);
    Raylib.EndDrawing();
}
