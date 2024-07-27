using ChessProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Classes
{ 
    internal enum eColor:byte
    {
        Black,
        White,
    }
    internal abstract class ChessPiece
    {
        internal byte m_PointValue { get; set; }
        internal  Position? m_Position { get; set; }
        internal eColor? m_Color { get; set; }
        
        internal abstract bool CheckMove(Position i_newPosition,int i_diffRow,int i_diffColumn);

        internal  bool Move(Position i_newPosition)
        {
            bool validMove = false;
            int diffRow = this.m_Position.m_Row - i_newPosition.m_Row;
            int diffColumn = this.m_Position.m_Column - i_newPosition.m_Column;
            if (CheckMove(i_newPosition,diffRow,diffColumn))
            {
                m_Position = i_newPosition;
                validMove = true;
            }
            return validMove;
        }
        internal ChessPiece(Position i_Position,eColor i_Color, byte i_PointValue)
        {
            m_Position = i_Position;
            m_Color = i_Color;
            m_PointValue = i_PointValue;
        }
                          
    }

    internal class King : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition, int i_diffRow, int i_diffColumn)
        {
            bool validMove = false;
            if((i_diffRow==1||i_diffRow==-1)&i_diffColumn==0)
            {
                validMove = true;//move up or down by 1
            }
            if ((i_diffColumn == 1 || i_diffColumn == -1) & i_diffRow == 0)
            {
                validMove = true;//move left or right by one
            }
            return validMove;
        }
        internal King(Position i_Position, eColor i_Color) : base(i_Position, i_Color,0)
        {

        }
    }

    internal class Queen : ChessPiece
    {
        
        internal override bool CheckMove(Position i_newPosition,int i_diffRow, int i_diffColumn)
        {

            return HelpingFunctions.IsDiagonal(i_diffRow, i_diffColumn) || HelpingFunctions.IsUpOrDown(i_diffRow, i_diffColumn);
        }
       internal Queen(Position i_Position, eColor i_Color) : base(i_Position, i_Color,9)
        {

        }
      
        
    }

    internal class Rook : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition, int i_diffRow, int i_diffColumn)
        {
            bool validMove = false;
            
            validMove =  HelpingFunctions.IsUpOrDown(i_diffRow, i_diffColumn);
            return validMove;
        }
        internal Rook(Position i_Position, eColor i_Color) : base(i_Position, i_Color,5)
        {

        }


    }
    internal class Bishop : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition, int i_diffRow, int i_diffColumn)
        {
            bool validMove = false;

            validMove = HelpingFunctions.IsDiagonal(i_diffRow, i_diffColumn);
            return validMove;
        }
        internal Bishop(Position i_Position, eColor i_Color) : base(i_Position, i_Color, 5)
        {

        }


    }

    internal class Knight : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition, int i_diffRow, int i_diffColumn)
        {
            bool validMove = false;

            validMove = HelpingFunctions.CheckKnightMove(i_diffRow, i_diffColumn);
            return validMove;
        }
        internal Knight(Position i_Position, eColor i_Color) : base(i_Position, i_Color, 5)
        {

        }


    }

    internal class Pawn : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition, int i_diffRow, int i_diffColumn)
        {
            bool validMove = false;

            if(i_diffRow==1 && i_diffColumn==0)
            {
                validMove =  true;//move up
            }
            else if (i_diffRow == 1 && i_diffColumn == 1)
            {
                validMove =  true;//move diagonal right
            }
            else if (i_diffRow == 1 && i_diffColumn == -1)
                validMove = true; //mobe diagonal left
            
            return validMove;
        }
        internal Pawn(Position i_Position, eColor i_Color) : base(i_Position, i_Color, 5)
        {

        }


    }
}
