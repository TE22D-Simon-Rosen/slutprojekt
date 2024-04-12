using Raylib_cs;

class Game
{

    int day = 1;
    Color fadeBlack = new Color(0, 0, 0, 0);
    public void EndDay(List<Plants> plants){
        day += 1;

        /*for (int i = 0; i <= plants.Count(); i++){
            plants[i].stage += 1;
        }
        */

        foreach (Plants plant in plants){
            if (plant.stage < plant.finalStage){
                plant.stage += 1;
            }
        }
        /*Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), fadeBlack);

        int time = 0;

        while (time <= 255){
            fadeBlack = new Color(0, 0, 0, time);
            time += 1;
            Thread.Sleep(10);
        }

        Raylib.DrawText("Day:", Raylib.GetScreenWidth() - 50, Raylib.GetScreenHeight() - 20, 20, Color.White);
        Thread.Sleep(1000);*/
    }
}
