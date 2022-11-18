/**
 * @file         Game.cs
 * @author	     Darren Morrison
 * @date         2022-09-27
 * @brief        User Interface Assignment 2
 * @details      Game class to handle TicTacToe.
 */

using System.Text.RegularExpressions;

/**
 * Class Game.
 */
class Game {
    // Init vars.
    private string sPlayerName1;
    private string sPlayerName2;
    private bool bPlayerTurn;
    private char[,] aGameBoard = new char[3, 3];

    /**
     * Constructor.
     */
    public Game(string sPlayerNameTemp1, string sPlayerNameTemp2) {
        sPlayerName1 = sPlayerNameTemp1;
        sPlayerName2 = sPlayerNameTemp2;

        // Start Game
        this.StartGame(); // Skips getting player names.
    }

    /**
     * Constructor.
     */
    public Game() {
        sPlayerName1 = "";
        sPlayerName2 = "";

        // Start Game
        this.MainLoop();
    }

    /**
     *  Main menu. Used to start a game or exit program.
     *  @return void No return
     */
    private void MainLoop() {
        this.ClearTerminal();
        while(true) {
            Console.Write("| Main Menu |\n1. Play TicTacToe Game\n2. Exit Program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^1$")) { this.ClearTerminal(); this.GetPlayerName1(); }
            else if(Regex.IsMatch(sInput, @"^2$")) { this.ExitProgram(); }
            else {
                Console.Write("Invalid Selection. Please select 1, or 2.\n\n");
            }
        }
    }

    /**
     *  Used to get Player1's name. Allows to go to main menu or exit program.
     *  @return void No return
     */
    private void GetPlayerName1() {
        while(true) {
            Console.Write("Please enter Player1's name. (Only letters and whitespace).\nEnter -1 to go to main menu\nEnter -2 to exit program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
            else if(Regex.IsMatch(sInput, @"^[A-Za-z ]+$")) { this.ClearTerminal(); this.sPlayerName1 = sInput; this.GetPlayerName2(); }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please enter a player name with only letters and whitespace. (Optional -1 for main menu, -2 to exit program\n");
          }
        }
    }

    /**
     *  Used to get Player2's name. Allows to go to main menu or exit program.
     *  @return void No return
     */
    private void GetPlayerName2() {
        while(true) {
            Console.Write("Please enter Player2's name. (Only letters and whitespace).\nEnter -1 to go to main menu\nEnter -2 to exit program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
            else if(Regex.IsMatch(sInput, @"^[A-Za-z ]+$")) { this.ClearTerminal(); this.sPlayerName2 = sInput; this.StartGame(); }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please enter a player name with only letters and whitespace. (Optional -1 for main menu, -2 to exit program\n");
            }
        }
    }

    /**
     *  Starts TicTacToe game. Clears board and resets player turn.
     *  @return void No return
     */
    private void StartGame() {
        // Init vars.
        this.bPlayerTurn = true;
        this.aGameBoard = new char[3, 3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        };

        // Game loop
        while(true) {
            this.PrintGameBoard();
            this.PrintPlayerTurn();
            this.GetPlayerMove();
            this.CheckPlayerWin();
            this.ClearTerminal();
            this.bPlayerTurn = !this.bPlayerTurn;
        }
        
    }

    /**
    *  Prints the game board.
    *  @return void No return
    */
    private void PrintGameBoard() {
        Console.Write("Player1(" + this.sPlayerName1 + ") = 'X', Player2(" + this.sPlayerName2 + ") = 'O'\n\n  GameBoard\n");
        for(int i = 0; i < 3; i++) {
            Console.Write("   ");
            for(int j = 0; j < 3; j++) {
                Console.Write("|" + this.aGameBoard[i, j]);
            }
            Console.Write("|\n");
        }
    }

    /**
    *  Prints Player turn to screen.
    *  @return void No return
    */
    private void PrintPlayerTurn() {
        if(this.bPlayerTurn) {
            Console.Write("Player1's Turn(X)\n");
        } else {
            Console.Write("Player2's Turn(O)\n");
        }
    }

    /**
    *  Gets Player Move and updates gameboard
    *  @return void No return
    */
    private void GetPlayerMove() {
        bool bLoop1 = true;
        while(bLoop1) {
            int iPlayerMoveRow = 0;
            int iPlayerMoveCol = 0;

            bool bLoop = true;
            while(bLoop) {
                Console.Write("\nPlease enter row for your move. (1-3 only).\nEnter -1 to go to main menu\nEnter -2 to exit program\n: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string sInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
                else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
                else if(Regex.IsMatch(sInput, @"^[1-3]$")) { iPlayerMoveRow = int.Parse(sInput); bLoop = false; }
                else {
                    this.ClearTerminal();
                    this.PrintGameBoard();
                    this.PrintPlayerTurn();
                    Console.Write("\nInvalid Selection. Please enter a valid row for your move(1-3 only). (Optional -1 for main menu, -2 to exit program\n");
                }
            }

            bLoop = true;
            while(bLoop) {
                Console.Write("\nPlease enter col for your move. (1-3 only).\nEnter -1 to go to main menu\nEnter -2 to exit program\n: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string sInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
                else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
                else if(Regex.IsMatch(sInput, @"^[1-3]$")) { iPlayerMoveCol = int.Parse(sInput); bLoop = false; }
                else {
                    this.ClearTerminal();
                    this.PrintGameBoard();
                    this.PrintPlayerTurn();
                    Console.Write("\nInvalid Selection. Please enter a valid col for your move(1-3 only). (Optional -1 for main menu, -2 to exit program\n");
                }
            }
            if(this.aGameBoard[iPlayerMoveRow-1, iPlayerMoveCol-1] == ' ') {
                char cPlayer = ' ';
                if(this.bPlayerTurn) { cPlayer = 'X'; }
                else cPlayer = 'O';
                this.aGameBoard[iPlayerMoveRow-1, iPlayerMoveCol-1] = cPlayer;
                bLoop1 = false;
            } else {
                this.ClearTerminal();
                this.PrintGameBoard();
                this.PrintPlayerTurn();
                Console.Write("\nInvalid Selection. Please enter a valid location for your move(Cannot be already played).\n");

            }
        }
    }

    /**
    *  Checks if Player has Won or game is stalemate.
    *  @return void No return
    */
    private void CheckPlayerWin() {
        // Init vars.
        char cPlayer = ' ';
        if(this.bPlayerTurn) { cPlayer = 'X'; }
        else cPlayer = 'O';

        // Check rows.
        if(this.aGameBoard[0, 0] == this.aGameBoard[0, 1] && this.aGameBoard[0, 1] == this.aGameBoard[0, 2] && this.aGameBoard[0, 2] == cPlayer) { this.PlayerWon(); }
        else if(this.aGameBoard[1, 0] == this.aGameBoard[1, 1] && this.aGameBoard[1, 1] == this.aGameBoard[1, 2] && this.aGameBoard[1, 2] == cPlayer) { this.PlayerWon(); }
        else if(this.aGameBoard[2, 0] == this.aGameBoard[2, 1] && this.aGameBoard[2, 1] == this.aGameBoard[2, 2] && this.aGameBoard[2, 2] == cPlayer) { this.PlayerWon(); }

        // Check cols.
        if(this.aGameBoard[0, 0] == this.aGameBoard[1, 0] && this.aGameBoard[1, 0] == this.aGameBoard[2, 0] && this.aGameBoard[2, 0] == cPlayer) { this.PlayerWon(); }
        else if(this.aGameBoard[0, 1] == this.aGameBoard[1, 1] && this.aGameBoard[1, 1] == this.aGameBoard[2, 1] && this.aGameBoard[2, 1] == cPlayer) { this.PlayerWon(); }
        else if(this.aGameBoard[0, 2] == this.aGameBoard[1, 2] && this.aGameBoard[1, 2] == this.aGameBoard[2, 2] && this.aGameBoard[2, 2] == cPlayer) { this.PlayerWon(); }

        // Check diag.
        if(this.aGameBoard[0, 0] == this.aGameBoard[1, 1] && this.aGameBoard[1, 1] == this.aGameBoard[2, 2] && this.aGameBoard[2, 2] == cPlayer) { this.PlayerWon(); }
        else if(this.aGameBoard[0, 2] == this.aGameBoard[1, 1] && this.aGameBoard[1, 1] == this.aGameBoard[2, 0] && this.aGameBoard[2, 0] == cPlayer) { this.PlayerWon(); }

        // Check Stalemate.
        int iCount = 0;
        for(int i=0; i<3; i++) {
            for(int j = 0; j < 3; j++) {
                if(this.aGameBoard[i, j] == ' ') iCount++;
            }
        }
        if(iCount == 0) this.Stalemate();
    }

    /**
    *  Outputs user has won and allows to restart game, exit program, or go to main menu.
    *  @return void No return
    */
    private void PlayerWon() {
        this.ClearTerminal();
        if(this.bPlayerTurn) {
            Console.Write("Player1(" + this.sPlayerName1 + ") has WON!\n\n");
        } else Console.Write("Player2(" + this.sPlayerName2 + ") has WON!\n\n");

        while(true) {
            Console.Write("Enter Selection\n1. Play again with same players\n2. Main Menu\n3. Exit Program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^1$")) { this.StartGame(); }
            else if(Regex.IsMatch(sInput, @"^2$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^3$")) { this.ExitProgram(); }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please select 1, 2 or 3.\n\n");
            }
        }
    }

    /**
    *  Outputs game is stalemate and allows to restart game, exit program, or go to main menu.
    *  @return void No return
    */
    private void Stalemate() {
        this.ClearTerminal();
        Console.Write("Game ends in Stalemate!\n\n");

        while(true) {
            Console.Write("Enter Selection\n1. Play again with same players\n2. Main Menu\n3. Exit Program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^1$")) { this.StartGame(); }
            else if(Regex.IsMatch(sInput, @"^2$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^3$")) { this.ExitProgram(); }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please select 1, 2 or 3.\n\n");
            }
        }
    }

    /**
    *  Exits program with exit message.
    *  @return void No return
    */
    public void ExitProgram() { this.ClearTerminal(); Console.Write("Game exit. Goodbye!"); System.Environment.Exit(1); }

    /**
    *  Clears terminal.
    *  @return void No return
    */
    public void ClearTerminal() { Console.Clear(); }
}