# Ship class
*The class object represents one of the ship types the game*
###### Ship types:
* Carrier (occupies 5 squares) - Type abbreviation: CA
* Battleship (4) - B
* Cruiser (3) - CR
* Submarine (3) - S
* Destroyer (2) - D

#### Fields
Name | Type | Description
-----|------|------------
Type | enum (CA/B/CR/S/D) | Type of the ship, based on it its size is set
Size | int | Size of the ship (nb of Square that build a ship)
Layout | enum (HORIZONTAL/VERTICAL) | Layout of the ship
Squares | List<Square> | List of the squares that build a ship  

#### Instance methods
Name | Arguents | Return | Throws exceptions | Description
-----|----------|--------|-------------------|------------
None |----------|--------|-------------------|------------
