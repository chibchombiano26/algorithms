using System;
using System.Collections.Generic;

namespace maze_core
{
    class Program
    {
        static List<List<int>> maze;
        static void Main(string[] args)
        {
            maze = new List<List<int>>();
            maze.Add(new List<int>() { 0, 1, 0, 1 });
            maze.Add(new List<int>() { 0, 0, 0, 1 });
            maze.Add(new List<int>() { 0, 0, 1, 0 });
            maze.Add(new List<int>() { 1, 0, 0, 0 });

            List<Position> positions = new List<Position>();
            positions.Add(new Position() { column = 0, row = 0 });
            var result = solve_maze_helper(maze, ref positions);
            result.ForEach(b => Console.Write(string.Format("[{0} , {1}]\t", b.row, b.column)));
        }

        /*        
        maze = [
           [0, 1,  0, 1],
           [0, 0,  0, 1],
           [1, 0,  1, 0],
           [0, 0,  0, 0]
       ] */

        private static List<Position> solve_maze_helper(List<List<int>> maze, ref List<Position> positions)
        {
            var position = positions[positions.Count - 1];
            if (position.row > maze.Count -1){
                return new List<Position>();
            }
            if (position.column > maze[0].Count -1){
                return new List<Position>();
            }
            if (maze[position.row][position.column] == 1)
            {
                return new List<Position>();
            }

            positions.Add(new Position(){row = position.row +1, column = position.column });
            var move_right = solve_maze_helper(maze, ref positions);
            if(move_right.Count > 0){
                return move_right;
            }
            else{
                positions.RemoveAt(positions.Count -1);
            }

            positions.Add(new Position(){row = position.row, column = position.column +1 });
            var move_down = solve_maze_helper(maze, ref positions);
            if(move_down.Count > 0){
                return move_down;
            }
            else{
                positions.RemoveAt(positions.Count -1);
            }

            return positions;
        }
    }

    class Position
    {
        public int row { get; set; }
        public int column { get; set; }
    }
}
