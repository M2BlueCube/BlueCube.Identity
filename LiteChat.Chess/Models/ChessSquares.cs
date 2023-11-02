namespace LiteChat.Chess.Models;

public record ChessSquares(byte X, char Y)
{
    public bool IsValidChessSquare() => X is >= 1 and <= 8 && Y is >= 'A' and <= 'H';
    
    public static ChessSquares A1 => new(1, 'A');
    public static ChessSquares A2 => new(2, 'A');
    public static ChessSquares A3 => new(3, 'A');
    public static ChessSquares A4 => new(4, 'A');
    public static ChessSquares A5 => new(5, 'A');
    public static ChessSquares A6 => new(6, 'A');
    public static ChessSquares A7 => new(7, 'A');
    public static ChessSquares A8 => new(8, 'A');
    
    public static ChessSquares B1 => new(1, 'B');
    public static ChessSquares B2 => new(2, 'B');
    public static ChessSquares B3 => new(3, 'B');
    public static ChessSquares B4 => new(4, 'B');
    public static ChessSquares B5 => new(5, 'B');
    public static ChessSquares B6 => new(6, 'B');
    public static ChessSquares B7 => new(7, 'B');
    public static ChessSquares B8 => new(8, 'B');
    
    public static ChessSquares C1 => new(1, 'C');
    public static ChessSquares C2 => new(2, 'C');
    public static ChessSquares C3 => new(3, 'C');
    public static ChessSquares C4 => new(4, 'C');
    public static ChessSquares C5 => new(5, 'C');
    public static ChessSquares C6 => new(6, 'C');
    public static ChessSquares C7 => new(7, 'C');
    public static ChessSquares C8 => new(8, 'C');
    
    public static ChessSquares D1 => new(1, 'D');
    public static ChessSquares D2 => new(2, 'D');
    public static ChessSquares D3 => new(3, 'D');
    public static ChessSquares D4 => new(4, 'D');
    public static ChessSquares D5 => new(5, 'D');
    public static ChessSquares D6 => new(6, 'D');
    public static ChessSquares D7 => new(7, 'D');
    public static ChessSquares D8 => new(8, 'D');
    
    public static ChessSquares E1 => new(1, 'E');
    public static ChessSquares E2 => new(2, 'E');
    public static ChessSquares E3 => new(3, 'E');
    public static ChessSquares E4 => new(4, 'E');
    public static ChessSquares E5 => new(5, 'E');
    public static ChessSquares E6 => new(6, 'E');
    public static ChessSquares E7 => new(7, 'E');
    public static ChessSquares E8 => new(8, 'E');
    
    public static ChessSquares F1 => new(1, 'F');
    public static ChessSquares F2 => new(2, 'F');
    public static ChessSquares F3 => new(3, 'F');
    public static ChessSquares F4 => new(4, 'F');
    public static ChessSquares F5 => new(5, 'F');
    public static ChessSquares F6 => new(6, 'F');
    public static ChessSquares F7 => new(7, 'F');
    public static ChessSquares F8 => new(8, 'F');
    
    public static ChessSquares G1 => new(1, 'G');
    public static ChessSquares G2 => new(2, 'G');
    public static ChessSquares G3 => new(3, 'G');
    public static ChessSquares G4 => new(4, 'G');
    public static ChessSquares G5 => new(5, 'G');
    public static ChessSquares G6 => new(6, 'G');
    public static ChessSquares G7 => new(7, 'G');
    public static ChessSquares G8 => new(8, 'G');
    
    public static ChessSquares H1 => new(1, 'H');
    public static ChessSquares H2 => new(2, 'H');
    public static ChessSquares H3 => new(3, 'H');
    public static ChessSquares H4 => new(4, 'H');
    public static ChessSquares H5 => new(5, 'H');
    public static ChessSquares H6 => new(6, 'H');
    public static ChessSquares H7 => new(7, 'H');
    public static ChessSquares H8 => new(8, 'H');
    
    public static ChessSquares[] AllSquares = new[]
    {
        A1, A2, A3, A4, A5, A6, A7, A8,
        B1, B2, B3, B4, B5, B6, B7, B8,
        C1, C2, C3, C4, C5, C6, C7, C8,
        D1, D2, D3, D4, D5, D6, D7, D8,
        E1, E2, E3, E4, E5, E6, E7, E8,
        F1, F2, F3, F4, F5, F6, F7, F8,
        G1, G2, G3, G4, G5, G6, G7, G8,
        H1, H2, H3, H4, H5, H6, H7, H8,
    };
    
    public static ChessSquares[] AllASquares = new[]
    {
        A1, A2, A3, A4, A5, A6, A7, A8,
    };
    
    public static ChessSquares[] AllBSquares = new[]
    {
        B1, B2, B3, B4, B5, B6, B7, B8,
    };
    
    public static ChessSquares[] AllCSquares = new[]
    {
        C1, C2, C3, C4, C5, C6, C7, C8,
    };
    
    public static ChessSquares[] AllDSquares = new[]
    {
        D1, D2, D3, D4, D5, D6, D7, D8,
    };
    
    public static ChessSquares[] AllESquares = new[]
    {
        E1, E2, E3, E4, E5, E6, E7, E8,
    };
    
    public static ChessSquares[] AllFSquares = new[]
    {
        F1, F2, F3, F4, F5, F6, F7, F8,
    };
    
    public static ChessSquares[] AllGSquares = new[]
    {
        G1, G2, G3, G4, G5, G6, G7, G8,
    };
    
    public static ChessSquares[] AllHSquares = new[]
    {
        H1, H2, H3, H4, H5, H6, H7, H8,
    };
    
    public static ChessSquares[] All1Squares = new[]
    {
        A1, B1, C1, D1, E1, F1, G1, H1,
    };
    
    public static ChessSquares[] All2Squares = new[]
    {
        A2, B2, C2, D2, E2, F2, G2, H2,
    };
    
    public static ChessSquares[] All3Squares = new[]
    {
        A3, B3, C3, D3, E3, F3, G3, H3,
    };
    
    public static ChessSquares[] All4Squares = new[]
    {
        A4, B4, C4, D4, E4, F4, G4, H4,
    };
    
    public static ChessSquares[] All5Squares = new[]
    {
        A5, B5, C5, D5, E5, F5, G5, H5,
    };
    
    public static ChessSquares[] All6Squares = new[]
    {
        A6, B6, C6, D6, E6, F6, G6, H6,
    };
    
    public static ChessSquares[] All7Squares = new[]
    {
        A7, B7, C7, D7, E7, F7, G7, H7,
    };
    
    public static ChessSquares[] All8Squares = new[]
    {
        A8, B8, C8, D8, E8, F8, G8, H8,
    };
}