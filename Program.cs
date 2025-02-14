using System;
using System.Collections.Generic;

public class Program{
    
    int gridsize = 17, snakelength = 5, applePOSy, applePOSx;
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
        mc.createGrid();

        while(true) {
            char input = Console.ReadKey().KeyChar;

            if(input == 'a' && v != 1) { h = 0; v = -1; }
            if(input == 'd' && v != -1) { h = 0; v = 1; }
            if(input == 'w' && h != 1) { v = 0; h = -1; } 
            if(input == 's' && h != -1) { v = 0; h = 1; }

            mc.moveSnake(h, v);
            mc.createGrid();
        }
    }

    void moveSnake(int h, int v){
        int currentPOSx = snakePOSx[0] + h;
        int currentPOSy = snakePOSy[0] + v;


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

        for (int i = 0; i < gridsize; i++) {
            for (int j = 0; j < gridsize; j++) {
                Console.Write(grid[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }
}