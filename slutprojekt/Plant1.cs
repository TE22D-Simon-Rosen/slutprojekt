using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

class Plants
{
    Vector2 position = new(0,0);
    float size = 10;
    int type = 0; // Which type of plant it is. 0 = blueberry, 1 = strawberry, 2 = carrot, 3 = raspberry
    int stage = 1; // Stage will go up by 1 each day
    int finalStage = 0; // Fully grown when stage = finalStage 
    public Rectangle plantRect = new Rectangle(0, 0, 10, 10);

    // Colors
    static Color carrotOutline = new Color(255, 132, 0, 255);
    static Color raspberryColor = new Color(237, 38, 114, 255);
    static Color raspberryOutline = new Color(242, 80, 142, 255);


    static Color[,] plantTypes = {{Color.Blue, Color.DarkBlue}, {Color.Red, Color.Maroon}, {Color.Orange, carrotOutline}, {raspberryColor, raspberryOutline}};
    // Filled with colors since colors is what differentiates the plants

    public void DrawPlant(Plants plant){

        Raylib.DrawCircleV(plant.position, plant.size, plantTypes[type, 0]); // Draws the plant

        if (stage == finalStage){
            Raylib.DrawCircleLinesV(plant.position, 10, plantTypes[type, 1]); // If fully grown then draw an outline to show that
        }
    }

    public void PlacePlant(Plants plant, Player player, List<Plants> plants){
        position = player.position + player.direction + new Vector2(25, 25); // Sets the plant position to the center of the "looking" square that the player has
        plantRect.X = (int)position.X; // Changes the rect position to the plants position above
        plantRect.Y = (int)position.Y; // ^

        plant.type = player.selectedPlant - 2; // subtract 2 to work with plantTypes array
        plants.Add(plant); // Adds the plant to a list so it can be drawn from a foreach loop
    }
}