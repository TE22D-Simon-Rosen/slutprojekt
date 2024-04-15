using Raylib_cs;

class Game
{
    public int currentDay = 1;
    public int timer = 0;
    public string scene = "game";
    public Rectangle bed = new Rectangle(0, 0, 100, 100);


    public void DrawBed()
    {
        Raylib.DrawRectangleRec(bed, Color.Yellow);
    }

    public void EndDay(Rectangle player, List<Plants> plants)
    {
        currentDay += 1;

        foreach (Plants plant in plants)
        {
            if (plant.stage < plant.finalStage)
            {
                plant.stage += 1;
            }
        }
    }

    public void Sleep()
    {
        if (timer < 60 * 5) // If the times is less than 5 seconds
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
}
