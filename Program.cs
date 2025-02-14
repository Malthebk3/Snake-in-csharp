using System;
using System.Collections.Generic;

public class Program{
    
    int gridsize = 17, snakelength = 5, applePOSy, applePOSx, randAppleSpawnX = 3, randAppleSpawnY = 3;
    List<int> snakePOSx = new List<int>();
    List<int> snakePOSy = new List<int>();
    char[,] grid;
    

    public Program() {
        grid = new char[gridsize, gridsize];

        int startX = gridsize / 2;
        int startY = gridsize / 2;

        for (int i = 0; i < snakelength; i++) {
            snakePOSx.Insert(0, startX); 
            snakePOSy.Insert(0, startY - i); 
        }
    }
    static void Main(){     //MAIN PART RUN
        int h = 0, v = -1;
        Console.Clear();
        Program mc = new Program();
        //mc.appleSpawn();
        mc.createGrid();

        while(true) {
            if (Console.KeyAvailable){
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char input = char.ToLower(keyInfo.KeyChar);

                if(input == 'a' && v != 1) { h = 0; v = -1; }
                if(input == 'd' && v != -1) { h = 0; v = 1; }
                if(input == 'w' && h != 1) { v = 0; h = -1; } 
                if(input == 's' && h != -1) { v = 0; h = 1; }
            }
            System.Threading.Thread.Sleep(100);
            mc.moveSnake(h, v);
            mc.createGrid();
        }
    }

    void appleSpawn() {
        do {
            Random r = new Random();
            randAppleSpawnX = r.Next(0, gridsize);
            randAppleSpawnY = r.Next(0, gridsize);
        } while (grid[randAppleSpawnY, randAppleSpawnX] != '.');
    }
    void moveSnake(int h, int v){
        int currentPOSx = snakePOSx[0] + h;
        int currentPOSy = snakePOSy[0] + v;

        if (currentPOSx < 0 || currentPOSx >= gridsize || currentPOSy < 0 || currentPOSy >= gridsize) {
            Console.WriteLine();
            Console.WriteLine("Game Over. Snake hit the wall. (Press 'CTRL + C' TO EXIT!)");
            System.Threading.Thread.Sleep(10000);
            Environment.Exit(0);
        }
        
        for (int i = 1; i < snakelength; ++i) {
            if (snakePOSx[i] == currentPOSx && snakePOSy[i] == currentPOSy) {
                Console.WriteLine();
                Console.WriteLine("Game Over. You ran into yourself. (Press 'CTRL + C' TO EXIT!)");
                System.Threading.Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }

        if (grid[currentPOSx, currentPOSy] == 'A') {
            snakelength++;
            appleSpawn();
        }

        snakePOSx.Insert(0, currentPOSx);
        snakePOSy.Insert(0, currentPOSy);   

        if (snakePOSx.Count > snakelength) { snakePOSx.RemoveAt(snakePOSx.Count - 1); }
        if (snakePOSy.Count > snakelength) { snakePOSy.RemoveAt(snakePOSy.Count - 1); }
    }

    void createGrid(){
        Console.SetCursorPosition(0, 0);

        for (int x = 0; x < gridsize; x++) {
            for (int y = 0; y < gridsize; y++) {
                grid[x, y] = '.';
            }
        }

        for (int i = 0; i < snakelength; ++i) {
            grid[snakePOSx[i], snakePOSy[i]] = 'O';
        }
        grid[randAppleSpawnX, randAppleSpawnY] = 'A';
        for (int i = 0; i < gridsize; i++) {
            for (int j = 0; j < gridsize; j++) {
                Console.Write(grid[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }
}