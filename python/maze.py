

def solve_maze(maze):
    return solve_maze_helper(maze, [(0, 0)])

def solve_maze_helper(maze, path):
    x, y = path[len(path) -1]
    if(x == len(maze) - 1 and y == len(maze[0]) -1):
        return path
    if(x >= len(maze) or y >= len(maze[0])) :
        return []
    if maze[x][y] ==1:
        return []
    move_right = solve_maze_helper(maze, path + [(x+1, y)])
    if move_right != []:
        return move_right
    move_down = solve_maze_helper(maze, path + [(x,y + 1)])
    if move_down != []:
        return move_down
    return []


maze = [
    [0, 1,  0, 1],
    [0, 0,  0, 1],
    [1, 0,  1, 0],
    [0, 0,  0, 0]
]

print(solve_maze(maze))
