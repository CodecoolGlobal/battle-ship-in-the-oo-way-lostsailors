# Ocean class
*The class object represents player's game board*

#### Fields
Name | Type | Description
-----|------|------------
Dimension | int | Size of the game board (dimension x dimension)
Squares | List<List<Square>> | List of lists containing Square type objects that build a game board

#### Instance methods
Name | Arguents | Return | Throws exceptions | Description
-----|----------|--------|-------------------|------------
displayOcean |-|void|-|-
putShipAtTheOcean | - | List<List<Square>> |-|-
checkShipInsideBoard | - | bool |-|-
checkShipsNotOverlap | - | bool |-|-
checkShipsNotTouch | - | bool |-|-
