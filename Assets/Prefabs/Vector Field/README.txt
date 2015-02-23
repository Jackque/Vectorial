Installation Instructions:

1.Place prefab in scene (hue)
2.Make sure included material is on the prefab. Should be a transparent teal
3.Place VectorFieldBehavior_Final.cs onto the included prefab
4.Set the properties on the VectorFieldBehavior_Final.cs script.
	i)Field Magnitude is a vector3 that represents the 3 dimensional vector of force that will be applies per frame to affectedObjects
	ii)Affected Objects is a GameObject[] array that contains all objects to be affected by the field.
	Set the size to 1 and drag "Player" from the hierarchy into the variable slot
5.?????
6.Profit!

====================================================================================================================================================
====================================================================================================================================================

Additional Notes:

Old scripts are fully functional

VectorFieldBehavior: Attach to prefab set Magnitude as an integer, then set direction as "up" "down" "left" or "right"

VectorFieldBehavior2: Attach to prefab. Same as Installation instructions but it only takes a single GameObject and you must attach the Helper script
to the Player.