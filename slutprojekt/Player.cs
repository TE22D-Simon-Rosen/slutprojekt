using System.Numerics;
using System.Runtime.Intrinsics;
using Raylib_cs;

class Player
{
    public Vector2 position = new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2); // Set to the middle of the screen
    public Vector2 size = new(50, 50);
    public Vector2 direction = new(50, 0); // Looking direction to show where the player is looking and where they can place a crop
    public int selectedPlant = 1; // Selected plant in hotbar, 1 = remove
    

    // Changes which direction the "place" square will point
    public void ChangeDirection(string direction, Player player){
        if (direction == "UP"){
            player.direction = new(0, -50);
        }
        else if (direction == "DOWN"){
            player.direction = new(0, 50);
        }
        else if (direction == "LEFT"){
            player.direction = new(-50, 0);
        }
        else if (direction == "RIGHT"){
            player.direction = new(50, 0);
        }
    }


    //Draw the hotbar
    static Color[] selectablePlants = {Color.White, Color.Blue, Color.Red, Color.Orange, Color.Pink};

    public void DrawHotbar(){ // Draws a rectangle 100 pixels from the bottom middle of the screen with a size of 400px horizontal, 75px vertical
        Raylib.DrawRectangle(Raylib.GetScreenWidth() / 2 - 200, Raylib.GetScreenHeight() - 100, 400, 75, Color.Beige);

        for (int i = 0; i < 5; i++){ // Draws 5 slots in the hotbar
            Raylib.DrawRectangle(Raylib.GetScreenWidth() / 2 - 188 + 80 * i, Raylib.GetScreenHeight() - 90, 55, 55, selectablePlants[i]);

            if (i+1 == selectedPlant){ // Draws an outline around the selected slot
               Raylib.DrawRectangleLines(Raylib.GetScreenWidth() / 2 - 188 + 80 * i, Raylib.GetScreenHeight() - 90, 55, 55, Color.SkyBlue);
            }
        }
    }


    public void RemovePlant(List<Plants> listOfPlants){
        for (int i = 0; i < listOfPlants.Count(); i++){
            if (listOfPlants[i].position == position + direction + new Vector2(25, 25)){ // if the plant the forloop is checking is the same one that the player wants removed
                listOfPlants.Remove(listOfPlants[i]); // remove
            }
        }
    }
}
