namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const int ScoreBoardSize = 6;
        private const int MaxPoints = 35;
        private const string StartMessage =
            "Let's play some minesweeper. Try your luck in finding the fields without any mines.";
        private const string InstructionsMessage =
            "Command 'top' shows the scoreboard, 'restart' starts a new game and 'exit' closes the game. Good luck!";
        private const string EnterCommandMessage = "Enter command: ";
        private const string DeathMessage = "BOOM! You died like a hero with {0} points. Enter your nickname: ";
        private const string WinMessage = "Well done! You uncovered {0} cells without a single scratch.";
        private const string EnterNicknameMessage = "Enter your nickname: ";
        private const string ExitMessage = "Made in Bulgaria.{0}Please, press ENTER to EXIT.";
        private const string ByeMessage = "Bye, bye!";
        private const string InvalidCommandMessage =
            "Error! Invalid command. Please, provide a valid row and col number separated by a single space.";
        private const string PointsMessage = "Points:";
        private const string ScoreboardIsEmptyMessage = "Scoreboard is empty!";

        public void Run()
        {
            string command;
            char[,] field = CreateField();
            char[,] mines = ArmMines();
            int count = 0;
            bool mineTriggered = false;
            List<Player> topPlayers = new List<Player>(ScoreBoardSize);
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            bool isFieldCleared = false;
            do
            {
                AttemptToPrintNewGameText(ref isNewGame, field);
                Console.Write(EnterCommandMessage);
                string line = Console.ReadLine();
                if (line != null)
                {
                    command = line.Trim();
                }
                else
                {
                    command = null;
                }
                command = GetCommandStats(command, field, ref row, ref col);
                field = ProcessCommand(command, topPlayers, field, row, col, ref mines, 
                    ref mineTriggered, ref isNewGame, ref count, ref isFieldCleared);
                AttemptMineTriggeredAction(ref mineTriggered, topPlayers, 
                    ref mines, ref count, ref field, ref isNewGame);
                AttemptFieldClearedAction(ref isFieldCleared, topPlayers, 
                    ref mines, ref count, ref field, ref isNewGame);
            } while (command != "exit");
            Console.WriteLine(ExitMessage, Environment.NewLine);
            Console.ReadKey();
        }

        private static void AttemptFieldClearedAction(ref bool isFieldCleared, List<Player> topPlayers,
            ref char[,] mines, ref int count, ref char[,] field, ref bool isNewGame)
        {
            if (isFieldCleared)
            {
                Console.WriteLine();
                Console.WriteLine(WinMessage, MaxPoints);
                PrintFieldState(mines);
                Console.Write(EnterNicknameMessage);
                string name = Console.ReadLine();
                Player player = new Player(name, count);
                topPlayers.Add(player);
                PrintScoreboard(topPlayers);
                field = CreateField();
                mines = ArmMines();
                count = 0;
                isFieldCleared = false;
                isNewGame = true;
            }
        }

        private static void AttemptMineTriggeredAction(ref bool mineTriggered, List<Player> topPlayers,
            ref char[,] mines, ref int count, ref char[,] field, ref bool isNewGame)
        {
            if (mineTriggered)
            {
                PrintFieldState(mines);
                Console.WriteLine();
                Console.Write(DeathMessage, count);
                string nickname = Console.ReadLine();
                Player player = new Player(nickname, count);
                int topPlayersCount = topPlayers.Count;
                if (topPlayersCount < 5)
                {
                    topPlayers.Add(player);
                }
                else
                {
                    for (int i = 0; i < topPlayersCount; i++)
                    {
                        if (topPlayers[i].Points < count)
                        {
                            topPlayers.Insert(i, player);
                            topPlayers.RemoveAt(topPlayersCount - 1);
                            break;
                        }
                    }
                }
                topPlayers.Sort((firstPlayer, secondPlayer) => String.Compare(
                    secondPlayer.Name, firstPlayer.Name, StringComparison.Ordinal));
                topPlayers.Sort((firstPlayer, secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                PrintScoreboard(topPlayers);
                field = CreateField();
                mines = ArmMines();
                count = 0;
                mineTriggered = false;
                isNewGame = true;
            }
        }

        private static string GetCommandStats(string command, char[,] field, ref int row, ref int col)
        {
            if (command.Length >= 3)
            {
                string command0String = command[0].ToString();
                string command2String = command[2].ToString();
                if (Int32.TryParse(command0String, out row)
                    && Int32.TryParse(command2String, out col)
                    && row <= field.GetLength(0)
                    && col <= field.GetLength(1))
                {
                    command = "turn";
                }
            }
            return command;
        }

        private static void AttemptToPrintNewGameText(ref bool isNewGame, char[,] field)
        {
            if (isNewGame)
            {
                Console.WriteLine(StartMessage);
                Console.WriteLine(InstructionsMessage);
                PrintFieldState(field);
                isNewGame = false;
            }
        }

        private static char[,] ProcessCommand(string command, List<Player> topPlayers, char[,] field, int row, int col,
            ref char[,] mines, ref bool mineTriggered, ref bool isNewGame, ref int count, ref bool isFieldCleared)
        {
            switch (command)
            {
                case "top":
                    PrintScoreboard(topPlayers);
                    break;
                case "restart":
                    field = ProcessRestartCommand(out mines, out mineTriggered, out isNewGame);
                    break;
                case "exit":
                    Console.WriteLine(ByeMessage);
                    break;
                case "turn":
                    ProcessTurnCommand(field, row, col, mines, ref mineTriggered, ref count, ref isFieldCleared);
                    break;
                default:
                    Console.WriteLine("{0}{1}{0}", Environment.NewLine, InvalidCommandMessage);
                    break;
            }
            return field;
        }

        private static char[,] ProcessRestartCommand(out char[,] mines, out bool mineTriggered, out bool isNewGame)
        {
            var field = CreateField();
            mines = ArmMines();
            PrintFieldState(field);
            mineTriggered = false;
            isNewGame = false;
            return field;
        }

        private static void ProcessTurnCommand(char[,] field, int row, int col, char[,] mines, ref bool mineTriggered,
            ref int count, ref bool isFieldCleared)
        {
            if (mines[row, col] != '*')
            {
                if (mines[row, col] == '-')
                {
                    char minesCount = GetNumberOfMinesAroundCell(mines, row, col);
                    mines[row, col] = minesCount;
                    field[row, col] = minesCount;
                    count++;
                }
                if (MaxPoints == count)
                {
                    isFieldCleared = true;
                }
                else
                {
                    PrintFieldState(field);
                }
            }
            else
            {
                mineTriggered = true;
            }
        }

        private static void PrintScoreboard(List<Player> players)
        {
            Console.WriteLine("{0}{1}", Environment.NewLine, PointsMessage);
            if (players.Count > 0)
            {
                int playersCount = players.Count;
                for (int i = 0; i < playersCount; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, players[i].Name, players[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("{0}{1}", ScoreboardIsEmptyMessage, Environment.NewLine);
            }
        }

        private static void PrintFieldState(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            string spaces = new string(' ', 3);
            string dashes = new string('-', 21);
            Console.WriteLine("\n {0}0 1 2 3 4 5 6 7 8 9", spaces);
            Console.WriteLine("{0}{1}", spaces, dashes);
            for (int r = 0; r < rows; r++)
            {
                Console.Write("{0} | ", r);
                for (int c = 0; c < cols; c++)
                {
                    Console.Write("{0} ", board[r, c]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("{0}{1}\n", spaces, dashes);
        }

        private static char[,] CreateField()
        {
            int fieldRows = 5;
            int fieldCols = 10;
            char[,] field = new char[fieldRows, fieldCols];
            for (int r = 0; r < fieldRows; r++)
            {
                for (int c = 0; c < fieldCols; c++)
                {
                    field[r, c] = '?';
                }
            }
            return field;
        }

        private static char[,] ArmMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    field[r, c] = '-';
                }
            }
            List<int> randomList = new List<int>();
            while (randomList.Count < 15)
            {
                Random random = new Random();
                int randomInt = random.Next(50);
                if (!randomList.Contains(randomInt))
                {
                    randomList.Add(randomInt);
                }
            }
            foreach (int num in randomList)
            {
                int col = num / cols;
                int row = num % cols;
                if (row == 0 && num != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                field[col, row - 1] = '*';
            }
            return field;
        }

        private static char GetNumberOfMinesAroundCell(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);
            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return (char) (count + '0');
        }
    }
}
