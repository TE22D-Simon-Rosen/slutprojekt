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
    }

    public int AddValuesAndMultiplyBy3(int a, int b){
        int newValue = a + b * 3;
        return newValue;
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


    public void ShowTutorial()
    {
        Raylib.DrawRectangle(300, 200, 600, 400, Color.Gray);
        Raylib.DrawText("Press E to return", 325, 225, 20, Color.White);

        Raylib.DrawText("Place a plant by selecting it with 2, 3, 4 or 5", 325, 255, 20, Color.White);
        Raylib.DrawText("and place it using M", 325, 275, 20, Color.White);

        Raylib.DrawText("To remove a plant, select the remove tool with 1", 325, 305, 20, Color.White);
        Raylib.DrawText("and press M on the selected plant", 325, 325, 20, Color.White);

        Raylib.DrawText("For plants to grow and to earn money, ", 325, 355, 20, Color.White);
        Raylib.DrawText("you need to sleep at the sleep spot in the top left", 325, 375, 20, Color.White);

        Raylib.DrawText("To sleep, press E when in the sleep spot", 325, 395, 20, Color.White);

        if (Raylib.IsKeyPressed(KeyboardKey.E)){
            scene = "start";
        }
    }
}
