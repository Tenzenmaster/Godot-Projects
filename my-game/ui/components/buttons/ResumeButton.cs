using Godot;
using System;

namespace MyGame;

public partial class ResumeButton : Button
{
	private Ui _ui;

	public override void _Ready()
	{
		_ui = GetNode<Ui>("/root/Ui");
	}

	private void OnPressed()
	{
		_ui.Clear();
	}
}
