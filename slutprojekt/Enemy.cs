using System.Numerics;
using Raylib_cs;


class Enemy
{
    public int hp = 10;
    public Vector2 position = new(0, 0);
    public Vector2 size = new(35, 35);
    public Rectangle enemyRect = new Rectangle();


    public void Spawn(Enemy target, int x, int y, List<Enemy> list){
        list.Add(target);
        target.position.X = x;
        target.position.Y = y;

        target.enemyRect.Position = target.position;
        target.enemyRect.Size = target.size;
    }
}