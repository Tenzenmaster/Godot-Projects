using Godot;
using System;

namespace MyGame;

public partial class LoadMenuButton : Button
{
	[Export]
	private PackedScene targetMenu;
	private Ui _ui;

	public override void _Ready()
	{
		_ui = GetNode<Ui>("/root/Ui");
	}

	private void OnPressed()
	{
		_ui.Push(targetMenu);
	}
}
