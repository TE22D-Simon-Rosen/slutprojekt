using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

class Plants
{
    static Vector2 position = new(0,0);
    static Vector2 size = new(10, 10);
    int type = 0; // Which type of plant it is. 0 = blueberry, 1 = strawberry, 2 = carrot, 3 = raspberry
    int stage = 1; // Stage will go up by 1 each day
    int finalStage = 0; // Fully grown when stage = finalStage 
    public Rectangle plantRect = new Rectangle(0, 0, size);


    // Colors
    static Color blueberryColor = Color.Blue;
    static Color blueberryOutline = Color.DarkBlue;
    static Color strawberryColor = Color.Red;
    static Color strawberryOutline = Color.Maroon;
    static Color carrotColor = Color.Orange;
    static Color carrotOutline = new Color(255, 132, 0, 255);
    static Color raspberryColor = new Color(237, 38, 114, 255);
    static Color raspberryOutline = new Color(242, 80, 142, 255);


    static Color[,] plantTypes = { {blueberryColor, blueberryOutline}, {strawberryColor, strawberryOutline}, {carrotColor, carrotOutline}, {raspberryColor, raspberryOutline} };
    public void DrawPlant(Plants plant){
        Raylib.DrawRectangleRec(plant.plantRect, plantTypes[type, 0]); // Draws the plant

        if (stage == finalStage){
            Raylib.DrawRectangleLinesEx(plant.plantRect, 10, plantTypes[type, 1]); // If fully grown then draw an outline to show that
        }
    }

    public void PlacePlant(Plants plant, Player player, List<Plants> plants){
        position = player.position + player.direction;  // Sets the plant position to the "looking" square that the player has
        plantRect.X = (int)position.X;  // Changes the rect position to the plants position above
        plantRect.Y = (int)position.Y;  // ^

        plant.type = player.selectedPlant - 2; // subtract 2 to work with plantTypes array
        plants.Add(plant); // Adds the plant to a list so it can be drawn from a foreach loop
    }
}