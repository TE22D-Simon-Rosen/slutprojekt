using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1280, 720, "hejhej");
Raylib.SetTargetFPS(60);

Rectangle rect = new (, 20);

while (!Raylib.WindowShouldClose()){
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.DarkGray);

    Raylib.EndDrawing();
}


class Player{
    public Vector2 position = new Vector2(0, 0);
    
}