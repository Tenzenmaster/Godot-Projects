using Godot;
using System;

namespace MyGame;

public partial class QuitButton : Button
{
	private void onPressed()
	{
		GetTree().Quit();
	}
}
