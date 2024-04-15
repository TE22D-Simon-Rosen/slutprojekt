using Raylib_cs;

class Game
{
    public int currentDay = 1;
    public int timer = 0;
    public bool tutorial = false;
    public string scene = "start";
    public Rectangle bed = new Rectangle(0, 0, 100, 100);


    public void DrawBed()
    {
        Raylib.DrawRectangleRec(bed, Color.Yellow);
    }

    // Ends the day by making plants grow and selling inventory
    public void EndDay(List<Plants> plants, Player player)
    {
        currentDay += 1;

        foreach (Plants plant in plants)
        {
            if (plant.stage < plant.finalStage)
            {
                plant.stage += 1;
            }
        }

        player.money += player.inventory * 3;
        player.inventory = 0;
    }

    // Used to show a black screen for 3 seconds while the player sleeps
    public void Sleep()
    {
        if (timer < 60 * 3) // If the times is less than 5 seconds
        {
            Raylib.DrawRectangle(0, 0, 2000, 1000, Color.Black);
            Raylib.DrawText("Day:", Raylib.GetScreenWidth() / 2 - 70, Raylib.GetScreenHeight() / 2 - 20, 50, Color.White);
            Raylib.DrawText(currentDay.ToString(), Raylib.GetScreenWidth() / 2 + 50, Raylib.GetScreenHeight() / 2 - 20, 50, Color.White);
            timer += 1;
        }
        else
        {
            scene = "game";
        }
    }


    public void showTutorial()
    {

    }
}
