namespace LiteChat.Common.Models.Games.Chess;

public record ChessSquares(byte X, byte Y)
{
    public bool IsValidChessSquare() => X is >= 1 and <= 8 && Y is >= 1 and <= 8;

    public bool HorizontalDistance(ChessSquares square, out int value)
    {
        var xDistance = square.X - X;
        var yDistance = square.Y - Y;

        if (xDistance == 0)
        {
            value = yDistance;
            return true;
        }

        value = 0;
        return false;
    }

    public bool VerticalDistance(ChessSquares square, out int value)
    {
        var xDistance = square.X - X;
        var yDistance = square.Y - Y;

        if (yDistance == 0)
        {
            value = xDistance;
            return true;
        }

        value = 0;
        return false;
    }

    public bool DiagonalDistance(ChessSquares square, out int value) 
    {
        var xDistance = square.X - X;
        var yDistance = square.Y - Y;

        if (xDistance == yDistance)
        {
            value = yDistance;
            return true;
        }


        value = 0;
        return false;
    }

    public static ChessSquares None = new(0, 0);

    #region static Members

    public static ChessSquares A1 => new(1, 1);
    public static ChessSquares A2 => new(2, 1);
    public static ChessSquares A3 => new(3, 1);
    public static ChessSquares A4 => new(4, 1);
    public static ChessSquares A5 => new(5, 1);
    public static ChessSquares A6 => new(6, 1);
    public static ChessSquares A7 => new(7, 1);
    public static ChessSquares A8 => new(8, 1);

    public static ChessSquares B1 => new(1, 2);
    public static ChessSquares B2 => new(2, 2);
    public static ChessSquares B3 => new(3, 2);
    public static ChessSquares B4 => new(4, 2);
    public static ChessSquares B5 => new(5, 2);
    public static ChessSquares B6 => new(6, 2);
    public static ChessSquares B7 => new(7, 2);
    public static ChessSquares B8 => new(8, 2);

    public static ChessSquares C1 => new(1, 3);
    public static ChessSquares C2 => new(2, 3);
    public static ChessSquares C3 => new(3, 3);
    public static ChessSquares C4 => new(4, 3);
    public static ChessSquares C5 => new(5, 3);
    public static ChessSquares C6 => new(6, 3);
    public static ChessSquares C7 => new(7, 3);
    public static ChessSquares C8 => new(8, 3);

    public static ChessSquares D1 => new(1, 4);
    public static ChessSquares D2 => new(2, 4);
    public static ChessSquares D3 => new(3, 4);
    public static ChessSquares D4 => new(4, 4);
    public static ChessSquares D5 => new(5, 4);
    public static ChessSquares D6 => new(6, 4);
    public static ChessSquares D7 => new(7, 4);
    public static ChessSquares D8 => new(8, 4);

    public static ChessSquares E1 => new(1, 5);
    public static ChessSquares E2 => new(2, 5);
    public static ChessSquares E3 => new(3, 5);
    public static ChessSquares E4 => new(4, 5);
    public static ChessSquares E5 => new(5, 5);
    public static ChessSquares E6 => new(6, 5);
    public static ChessSquares E7 => new(7, 5);
    public static ChessSquares E8 => new(8, 5);

    public static ChessSquares F1 => new(1, 6);
    public static ChessSquares F2 => new(2, 6);
    public static ChessSquares F3 => new(3, 6);
    public static ChessSquares F4 => new(4, 6);
    public static ChessSquares F5 => new(5, 6);
    public static ChessSquares F6 => new(6, 6);
    public static ChessSquares F7 => new(7, 6);
    public static ChessSquares F8 => new(8, 6);

    public static ChessSquares G1 => new(1, 7);
    public static ChessSquares G2 => new(2, 7);
    public static ChessSquares G3 => new(3, 7);
    public static ChessSquares G4 => new(4, 7);
    public static ChessSquares G5 => new(5, 7);
    public static ChessSquares G6 => new(6, 7);
    public static ChessSquares G7 => new(7, 7);
    public static ChessSquares G8 => new(8, 7);

    public static ChessSquares H1 => new(1, 8);
    public static ChessSquares H2 => new(2, 8);
    public static ChessSquares H3 => new(3, 8);
    public static ChessSquares H4 => new(4, 8);
    public static ChessSquares H5 => new(5, 8);
    public static ChessSquares H6 => new(6, 8);
    public static ChessSquares H7 => new(7, 8);
    public static ChessSquares H8 => new(8, 8);

    public static ChessSquares[] AllSquares =
    [
        A1, A2, A3, A4, A5, A6, A7, A8,
        B1, B2, B3, B4, B5, B6, B7, B8,
        C1, C2, C3, C4, C5, C6, C7, C8,
        D1, D2, D3, D4, D5, D6, D7, D8,
        E1, E2, E3, E4, E5, E6, E7, E8,
        F1, F2, F3, F4, F5, F6, F7, F8,
        G1, G2, G3, G4, G5, G6, G7, G8,
        H1, H2, H3, H4, H5, H6, H7, H8,
    ];

    public static ChessSquares[] AllASquares =
    [
        A1, A2, A3, A4, A5, A6, A7, A8,
    ];

    public static ChessSquares[] AllBSquares =
    [
        B1, B2, B3, B4, B5, B6, B7, B8,
    ];

    public static ChessSquares[] AllCSquares =
    [
        C1, C2, C3, C4, C5, C6, C7, C8,
    ];

    public static ChessSquares[] AllDSquares =
    [
        D1, D2, D3, D4, D5, D6, D7, D8,
    ];

    public static ChessSquares[] AllESquares =
    [
        E1, E2, E3, E4, E5, E6, E7, E8,
    ];

    public static ChessSquares[] AllFSquares =
    [
        F1, F2, F3, F4, F5, F6, F7, F8,
    ];

    public static ChessSquares[] AllGSquares =
    [
        G1, G2, G3, G4, G5, G6, G7, G8,
    ];

    public static ChessSquares[] AllHSquares =
    [
        H1, H2, H3, H4, H5, H6, H7, H8,
    ];

    public static ChessSquares[] All1Squares =
    [
        A1, B1, C1, D1, E1, F1, G1, H1,
    ];

    public static ChessSquares[] All2Squares =
    [
        A2, B2, C2, D2, E2, F2, G2, H2,
    ];

    public static ChessSquares[] All3Squares =
    [
        A3, B3, C3, D3, E3, F3, G3, H3,
    ];

    public static ChessSquares[] All4Squares =
    [
        A4, B4, C4, D4, E4, F4, G4, H4,
    ];

    public static ChessSquares[] All5Squares =
    [
        A5, B5, C5, D5, E5, F5, G5, H5,
    ];

    public static ChessSquares[] All6Squares =
    [
        A6, B6, C6, D6, E6, F6, G6, H6,
    ];

    public static ChessSquares[] All7Squares =
    [
        A7, B7, C7, D7, E7, F7, G7, H7,
    ];

    public static ChessSquares[] All8Squares =
    [
        A8, B8, C8, D8, E8, F8, G8, H8,
    ];

    #endregion
}