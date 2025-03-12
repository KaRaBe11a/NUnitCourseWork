namespace TikTakEngine;

public class GameEngine
{
    private const int BoardSize = 10;
    private readonly char[,] board = new char[BoardSize, BoardSize];
    private char currentPlayer = 'X';

    public char CurrentPlayer { get { return currentPlayer; } }


    public GameEngine()
    {
        InitialBoard();
    }

    private void InitialBoard()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                board[i, j] = '-';
            }
        }
    }

    public bool MakeMove(int row, int col)
    {
        if (row < 0 || row >= BoardSize || col < 0 || col >= BoardSize || board[row, col] != '-')
            return false;
        board[row, col] = currentPlayer;
        return true;
    }

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    public bool CheckWin()
    {
        for (int i =0; i<BoardSize; i++)
        {
            for(int j =  0; j < BoardSize; j++)
            {
                if (board[i, j] != '-')
                {
                    if (CheckDirection(i, j, 1, 0) ||
                        CheckDirection(i, j, 0, 1) ||
                        CheckDirection(i, j, 1, 1) ||
                        CheckDirection(i, j, 1, -1)
                        )
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }



    private bool CheckDirection(int row, int col, int directionRow,  int directionCol)
    {
        char symbol = board[row, col];
        int count = 1;

        int r = row + directionRow;
        int c = col + directionCol;

        while (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize && board[r, c] == symbol)
        {
            count++;
            r += directionRow;
            c += directionCol;
        }

        r = row - directionRow;
        c = col - directionCol;

        while (r >= 0 && r < BoardSize && c >= 0 && c < BoardSize && board[r, c] == symbol)
        {
            count++;
            r -= directionRow;
            c -= directionCol;
        }

        return count >= 5;
    }

    public bool IsDraw()
    {
        for (int i = 0; i < BoardSize;  i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (board[i, j] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
