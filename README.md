
# American Checkers

An object-oriented driven American Checkers game made from scratch and developed in C#. The project is focused on explicit UI and logic separation, encapsulation, with clean and readable coding methodologies.


## Instructions

Tu start playing, run 'AmericanCheckersUI.exe'.
## Rules

- In the game of American Checkers, also known as English draughts, two players compete on the 64 squares of a standard checkerboard. They use only the dark squares (eight rows, eight columns), each controlling 12 Checkers in different colors, typically black and white.

- The board is set up between the players with a dark square on each player's left side and a double-corner to the right. Players arrange their Checkers on the three rows of dark squares closest to them. The one with the darker Checkers goes first, and the game continues with players taking turns, moving one piece at a time.

- The goal of the game is to stop the other player from being able to move on their turn. This can be achieved by either capturing all of their Checkers or by blocking their remaining Checkers, making movement impossible. If neither player can achieve this, the match ends in a draw.

- Regular Checkers, or "men," can move one square forward diagonally to an unoccupied spot. Men capture opponents by jumping over them diagonally to an empty square just beyond but only if this square is unoccupied. Men may jump forward only and can continue jumping if they encounter enemy Checkers with empty squares just beyond. Men must not jump over Checkers of their own color. It's important to note that men can indeed jump over Kings, contrary to some players' beliefs.

- A man that reaches the farthest row on the board becomes a King, ending that move. The opponent then must crown the new King by placing a matching Checker on top of it. Players can't continue their turn until they've crowned the new King.

- Kings can move diagonally forward or backward one square at a time to an empty square. Kings capture by jumping either forward or backward over an enemy man or King, landing on the unoccupied square just beyond. Kings can continue jumping under the same conditions as men, never jumping over the same opponent's piece more than once or over pieces of their own color.

- A player must capture if the opportunity arises. When multiple jumping paths are available, the player may select any path but must follow through with all possible jumps in that chosen path. Leaving Checkers uncaptured when they could have been jumped is not allowed. If an incorrect move is made, it must be corrected using the same Checker that was originally moved incorrectly, if possible. The practice known as "HUFF," penalizing a Checker for an incorrect jump, is no longer part of the game.

