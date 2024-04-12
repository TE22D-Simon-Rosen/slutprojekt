using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

class Plants
{
    public Vector2 position = new(0, 0);
    float size = 10;
    public int type = 0; // Which type of plant it is. 0 = blueberry, 1 = strawberry, 2 = carrot, 3 = raspberry
    public int stage = 1; // Stage will go up by 1 each day
    public int finalStage = 5; // Fully grown when stage = finalStage 
    public int growthRate = 0;
    public Rectangle plantRect = new Rectangle(0, 0, 10, 10);

    // Colors
    static Color carrotOutline = new Color(255, 132, 0, 255);
    static Color raspberryColor = new Color(237, 38, 114, 255);
    static Color raspberryOutline = new Color(242, 80, 142, 255);


    static Color[,] plantTypes = { { Color.Blue, Color.DarkBlue }, { Color.Red, Color.Maroon }, { Color.Orange, carrotOutline }, { raspberryColor, raspberryOutline } };
    // Filled with colors since colors is what differentiates the plants

    public void DrawPlant(Plants plant)
    {
        plant.size = plant.stage * plant.growthRate;

        Raylib.DrawCircleV(plant.position, plant.size, plantTypes[type, 0]); // Draws the plant

        if (plant.stage == finalStage)
        {
            Raylib.DrawCircleLinesV(plant.position, 25, plantTypes[type, 1]); // If fully grown then draw an outline to show that
        }
    }


    public void PlacePlant(Plants plant, Player player, List<Plants> plants)
    {
        plant.type = player.selectedPlant - 2; // subtract 2 to work with plantTypes array
        plants.Add(plant); // Adds the plant to a list so it can be drawn from a foreach loop'

        if (plant.type == 0)
        {
            plant.finalStage = 5;
            plant.growthRate = 5;
        }
        else if (plant.type == 1)
        {
            plant.finalStage = 5;
            plant.growthRate = 5;
        }
        else if (plant.type == 2)
        {
            plant.finalStage = 3;
        }
        else
        {
            plant.finalStage = 4;
        }


        for (int i = 0; i < plants.Count(); i++)
        {
            if (plants[i].position == player.position + player.direction + new Vector2(25, 25))
            {
                plants.Remove(plant);
            }
        }
    }
}