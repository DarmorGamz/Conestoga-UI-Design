/**
 * @file         Program.cs
 * @author	     Darren Morrison
 * @date         2022-09-14
 * @brief        User Interface Assignment 1
 * @details      Take user input for two matrix, and output the multiplicated result.
 */

// Init vars.
bool bRunState = true;

// Main Program.
while(bRunState == true) {
    UserSelection:
        // Init vars.
        sbyte sbUserSelection = 0;
        bool bRunStateUserSelection = true;

        // User Selection.
        while(bRunStateUserSelection) {
            // Init vars.
            sbUserSelection = 0;
            sbyte[] aValidUserSelection = {1, 2};

            // Get User's selection.
            Console.Write("1: Multiply two square matrices.\n2: Exit program.\nPlease enter selection: ");
            if(!ReadSBtye(Console.ReadLine(), ref sbUserSelection) || !aValidUserSelection.Contains(sbUserSelection)) {
                // User entered and invalid selection.
                Console.Write("Invalid selection!\n\n");

            } else if(2 == sbUserSelection) {
                // User selected program exit.
                Console.Write("GoodBye!\n");
                System.Environment.Exit(0);

            } else {
                // User entered a valid selection.
                bRunStateUserSelection = false;
            }
        }

    UserEnterMatrixSize1:
        // Init vars.
        sbyte sbMatrixSizeRows1 = 0;
        sbyte sbMatrixSizeCols1 = 0;
        bool bRunStateGetMatrixSize = true;

        // Get Matrix rows.
        while(bRunStateGetMatrixSize) {
            // Init vars.
            sbMatrixSizeRows1 = 0;

            // Get User's selection.
            Console.Write("\nEnter -1 to go to main menu.\nEnter -2 to exit program.\nPlease enter the first matrix's rows: ");
            if(!ReadSBtye(Console.ReadLine(), ref sbMatrixSizeRows1)) { 
                // User entered and invalid size.
                Console.Write("Invalid size!\n\n");
                continue; // Goes to top of while loop.
            } else if(-1 == sbMatrixSizeRows1) {
                // Return to main menu.
                Console.Write("\n");
                goto UserSelection;
            } else if(-2 == sbMatrixSizeRows1) {
                // User selected program exit.
                Console.Write("GoodBye!\n");
                System.Environment.Exit(0);
            } 

            // User entered a valid size.
            bRunStateGetMatrixSize = false;
        }

        bRunStateGetMatrixSize = true;

        // Get Matrix rows.
        while(bRunStateGetMatrixSize) {
            // Init vars.
            sbMatrixSizeCols1 = 0;

            // Get User's selection.
            Console.Write("\nEnter -1 to go to main menu.\nEnter -2 to re-enter first matrix's rows.\nPlease enter the first matrix's cols: ");
            if(!ReadSBtye(Console.ReadLine(), ref sbMatrixSizeCols1)) { 
                // User entered and invalid size.
                Console.Write("Invalid size!\n\n");
                continue; // Goes to top of while loop.
            } else if(-1 == sbMatrixSizeCols1) {
                // Return to main menu.
                Console.Write("\n");
                goto UserSelection;
            } else if(-2 == sbMatrixSizeCols1) {
                // Return to main menu.
                Console.Write("\n");
                goto UserEnterMatrixSize1;
            } 

            // User entered a valid size.
            bRunStateGetMatrixSize = false;
        }

    UserEnterMatrixSize2:
        // Init vars.
        sbyte sbMatrixSizeRows2 = 0;
        sbyte sbMatrixSizeCols2 = 0;
        bRunStateGetMatrixSize = true;

        // Get Matrix rows.
        while(bRunStateGetMatrixSize) {
        // Init vars.
        sbMatrixSizeRows2 = 0;

            // Get User's selection.
            Console.Write("\nEnter -1 to go to main menu.\nPlease enter the second matrix's rows: ");
            if(!ReadSBtye(Console.ReadLine(), ref sbMatrixSizeRows2)) { 
                // User entered and invalid size.
                Console.Write("Invalid size!\n\n");
                continue; // Goes to top of while loop.
            } else if(-1 == sbMatrixSizeRows2) {
                // Return to main menu.
                Console.Write("\n");
                goto UserSelection;
            }   

            // User entered a valid size.
            bRunStateGetMatrixSize = false;
        }

        bRunStateGetMatrixSize = true;

        // Get Matrix rows.
        while(bRunStateGetMatrixSize) {
            // Init vars.
            sbMatrixSizeCols2 = 0;

            // Get User's selection.
            Console.Write("\nEnter -1 to go to main menu.\nEnter -2 to re-enter matrix rows.\nPlease enter the second matrix's cols: ");
            if(!ReadSBtye(Console.ReadLine(), ref sbMatrixSizeCols2)) { 
                // User entered and invalid size.
                Console.Write("Invalid size!\n\n");
                continue; // Goes to top of while loop.
            } else if(-1 == sbMatrixSizeCols2) {
                // Return to main menu.
                Console.Write("\n");
                goto UserSelection;
            } else if(-2 == sbMatrixSizeCols2) {
                // Return to main menu.
                Console.Write("\n");
                goto UserEnterMatrixSize2;
            } 

            // User entered a valid size.
            bRunStateGetMatrixSize = false;
        }

        // Matrix will fail math below.
        if(sbMatrixSizeCols1 != sbMatrixSizeRows2) {
            Console.Write("\nMatrix are unable to multiply!\n");
            goto UserEnterMatrixSize1;
        }

    UserGetMatrixValues1:
        // Init vars.
        int[,] aaMatrixToMultiply1 = new int[sbMatrixSizeRows1, sbMatrixSizeCols1];
        int[,] aaMatrixToMultiply2 = new int[sbMatrixSizeRows2, sbMatrixSizeCols2];


        // Get Matrix vals.
        Console.Write("\nEnter first Matrix values:\n");
        bool bRunStateGetMatrixValues = true;
        while(bRunStateGetMatrixValues) {
            for(int i = 0; i < sbMatrixSizeCols1; i++) {
                for(int j = 0; j < sbMatrixSizeRows1; j++) {
                    Console.Write("[");
                    int firstPositionX = Console.CursorLeft;
                    bool bValidValue = true;
                    int iMatrixValue = 0;
                    int iValueLength = 0;
                    while(bValidValue) {
                        Console.SetCursorPosition(firstPositionX, Console.CursorTop);
                        string sTemp = Console.ReadLine();
                        if(ReadInt(sTemp, ref iMatrixValue)) {
                            bValidValue = false;
                            iValueLength = sTemp.Length;
                        }   
                    }
                    Console.SetCursorPosition(iValueLength + firstPositionX, Console.CursorTop-1);
                    Console.Write("] ");
                    aaMatrixToMultiply1[i, j] = iMatrixValue;
                }
                Console.Write("\n");
            }

            bRunStateGetMatrixValues = false;
            Console.Write("\n");
        }
    UserGetMatrixValues2:
        // Get Matrix vals.
        Console.Write("\nEnter second Matrix values:\n");
        bRunStateGetMatrixValues = true;
        while(bRunStateGetMatrixValues) {
            for(int i = 0; i < sbMatrixSizeRows2; i++) {
                for(int j = 0; j < sbMatrixSizeCols2; j++) {
                    Console.Write("[");
                    int firstPositionX = Console.CursorLeft;
                    bool bValidValue = true;
                    int iMatrixValue = 0;
                    int iValueLength = 0;
                    while(bValidValue) {
                        Console.SetCursorPosition(firstPositionX, Console.CursorTop); // Fancy cursor settings for User expierence!
                        string sTemp = Console.ReadLine();
                        if(ReadInt(sTemp, ref iMatrixValue)) {
                            bValidValue = false;
                            iValueLength = sTemp.Length;
                        }   
                    }
                    Console.SetCursorPosition(iValueLength + firstPositionX, Console.CursorTop-1);
                    Console.Write("] ");
                    aaMatrixToMultiply2[i, j] = iMatrixValue;
                }
                Console.Write("\n");
            }

            bRunStateGetMatrixValues = false;
            Console.Write("\n");
        }
    MultiplyMatrix:
        // Complete Matrix multiplication.
        int[,] aaResultMatrix = new int[0, 0];
        if(!MultipyIntMatrix(aaMatrixToMultiply1, aaMatrixToMultiply2, ref aaResultMatrix)) {
            Console.Write("Matrix are unable to multiply!\n");
            goto UserEnterMatrixSize1;
        }
        

    PrintResults:
        // Print First,Second,Result Matrix.
        Console.Write("First Matrix\n");
        for(int i = 0; i < sbMatrixSizeRows1; i++) {
            for(int j = 0; j < sbMatrixSizeCols1; j++) {
                Console.Write("[" + aaMatrixToMultiply1[i, j] + "] ");
            }
            Console.Write('\n');
        }
        Console.Write("\nSecond Matrix\n");
        for(int i = 0; i < sbMatrixSizeRows2; i++) {
            for(int j = 0; j < sbMatrixSizeCols2; j++) {
                Console.Write("[" + aaMatrixToMultiply2[i, j] + "] ");
            }
            Console.Write('\n');
        }
        int iRows = aaResultMatrix.GetLength(0);
        int iCols = aaResultMatrix.GetLength(1);

        Console.Write("\nResulted Matrix\n");
        for(int i = 0; i < iRows; i++) {
            for(int j = 0; j < iCols; j++) {
                Console.Write("[" + aaResultMatrix[i, j] + "] ");
            }
            Console.Write('\n');
        }
        Console.Write('\n');

    // Program end.
    goto UserSelection;
}

/*
 * Used to validate user entered sByte.
 * @param string sVarIn string to be parsed.
 * @param sbyte sbVarOut referencial sByte being returned.
 * @return bool Return success.
 */
static bool ReadSBtye(string sVarIn, ref sbyte sbVarOut) {
    // Verify valid value.
    if(!sbyte.TryParse(sVarIn, out sbVarOut)) return false;

    // Return Success.
    return true;
}

/*
 * Used to validate user entered int.
 * @param string sVarIn string to be parsed.
 * @param sbyte sbVarOut referencial sByte being returned.
 * @return bool Return success.
 */
static bool ReadInt(string sVarIn, ref int iVarOut) {
    // Verify valid value.
    if(!int.TryParse(sVarIn, out iVarOut))
        return false;

    // Return Success.
    return true;
}

/*
 * Used to Multiply two matrix.
 * @param int[][] aaArray1 First Matrix
 * @param int[][] aaArray2 Second Matrix
 * @param int[][] aaResult referencial result of matrix being multiplied.
 * @return bool Return success.
 */
static bool MultipyIntMatrix(int[,] aaArray1, int[,] aaArray2, ref int[,] aaResult) {
    // Get Matrix rows and cols.
    int iRows1 = aaArray1.GetLength(0);
    int iCols1 = aaArray1.GetLength(1);
    int iRows2 = aaArray2.GetLength(0);
    int iCols2 = aaArray2.GetLength(1);

    // Confirm math won't fail.
    if(iCols1 != iRows2) return false;

    // Matrix math *From the internet.
    int[,] aaResultMatrix = new int[iRows1, iCols2];
    int iTemp;
    for(int i = 0; i < iRows1; i++) {
        for(int j = 0; j < iCols2; j++) {
            iTemp = 0;
            for(int k = 0; k < iCols1; k++) {
                iTemp += aaArray1[i, k] * aaArray2[k, j];
            }
            aaResultMatrix[i, j] = iTemp;
        }
    }

    // Set Response.
    aaResult = aaResultMatrix;

    // Return Success.
    return true;
}