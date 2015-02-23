TileManager Script - Attaches to "TestUI" object; References "Player" object
VectorBuildPanel Script - Attaches to "VectorBuildUI" object; References "VectorBuildUI" animator

VectorBuildUI Animator - Attaches to "VectorBuildUI" object

For Button onClick():

"GOButton" - references "TestUI" object; calls TileManager.executeTile()
"BuildVectorButton"
	- references "VectorBuildUI" object; calls VectorBuildPanel.setBool(true); (the checkmark)
	- references "TestUI"; calls TileManager.addTile()
	- references "TestUI"; calls TileManager.changeUIState()
"AddUp" - references "TestUI"; calls TileManager.IncreaseYmag()
"AddDown" - references "TestUI"; calls TileManager.DecreaseYmag()
"AddLeft" - references "TestUI"; calls TileManager.DecreaseXmag()
"AddRight" - references "TestUI"; calls TileManager.IncreaseXmag()
"CloseButton"
	- references "VectorBuildUI"; calls VectorBuildPanel.setBool(false)
	- references "TestUI"; calls TileManager.changeUIState(false)