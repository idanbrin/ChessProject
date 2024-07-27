using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Services
{
    internal static class HelpingFunctions
    {
        internal static bool IsUpOrDown(int i_diffRow, int i_diffCol)
        {
            bool check = false;
            if ((i_diffRow == 1 || i_diffRow == -1) && i_diffCol == 0)
            {
                check = true;
            }
            else if ((i_diffCol == 1 || i_diffCol == -1) && i_diffRow == 0)
            {
                check = true;
            }
            return check;
        }
        internal static bool IsDiagonal(int i_diffRow, int i_diffCol)
        {
            bool check = false;
            if ((i_diffRow == i_diffCol))
            {
                check = true;
            }
           
            return check;
        }

        internal static bool CheckKnightMove(int i_diffRow, int i_diffCol)
        {
            bool check = false;
            if ((Math.Abs(i_diffRow) == 2 && Math.Abs(i_diffCol) == 1) || (Math.Abs(i_diffRow) == 1 && Math.Abs(i_diffCol) == 2))
            {
                check = true;
            }


            return check;

        }
    }
}
