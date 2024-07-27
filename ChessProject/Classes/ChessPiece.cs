using System;
using System.Collections.Generic;
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
        
        internal abstract bool CheckMove(Position i_newPosition);

        internal  bool Move(Position i_newPosition)
        {
            bool validMove = false;
            if(CheckMove(i_newPosition))
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

        internal override bool CheckMove(Position i_newPosition)
        {
            bool validMove = false;
            int differenceRow = this.m_Position.m_Row - i_newPosition.m_Row;
            int differenceColumn = this.m_Position.m_Column - i_newPosition.m_Column;
            //There are 2 cases - differenceRow = 1/-1 and differenceColumn=0, king move left or right
            //or differenceRow = 0 and differenceColumn=1/-1, king moves up or down
            if ((differenceRow == 1 || differenceRow == -1) && differenceColumn == 0 )
            {
                validMove = true;
            }
            else if((differenceColumn == 1 || differenceColumn == -1) && differenceRow == 0)
            {
                validMove = true;
            }
                return validMove;
        }
        internal King(Position i_Position, eColor i_Color) : base(i_Position, i_Color,0)
        {

        }
    }

    internal class Queen : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition)
        {
            return true;//the chess piece dont care about the size of the table or if the new
                        //position is full or empty - single responsibility principle
        }
       internal Queen(Position i_Position, eColor i_Color) : base(i_Position, i_Color,9)
        {

        }
      
        
    }

    internal class Rook : ChessPiece
    {

        internal override bool CheckMove(Position i_newPosition)
        {
            bool validMove = false;
            int differenceRow = this.m_Position.m_Row - i_newPosition.m_Row;
            int differenceColumn = this.m_Position.m_Column - i_newPosition.m_Column;
            //the rook is same as king but can move how many steps he wants
            if ((differenceRow>= 1 || differenceRow <= -1) && differenceRow == 0)
            {
                validMove = true;
            }
            else if ((differenceColumn >=1 || differenceColumn <=1 -1) && differenceRow == 0)
            {
                validMove = true;
            }
            return validMove;
        }
        internal Rook(Position i_Position, eColor i_Color) : base(i_Position, i_Color,5)
        {

        }


    }
}
