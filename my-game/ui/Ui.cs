using Godot;
using System;
using System.Collections.Generic;

namespace MyGame;

public partial class Ui : CanvasLayer
{
	[Export]
	private bool _pushMainMenuOnReady;

	public bool IsMenuStackEmpty { get => _menuStack.Count == 0; }
	private Stack<Control> _menuStack = new();

	public override void _Ready()
	{
		if (_pushMainMenuOnReady)
		{
			Push(GD.Load<PackedScene>("res://ui/menus/main_menu.tscn"));
		}
	}

	public void Push(PackedScene menuScene)
	{
		try
		{
			GetTree().Paused = true;
			Control newMenu = menuScene.Instantiate<Control>();
			if (!IsMenuStackEmpty) { _menuStack.Peek().Hide(); }
			_menuStack.Push(newMenu);
			AddChild(newMenu);
		}
		catch (InvalidCastException e)
		{
			GD.PrintErr("Pushed a non-control Node to _menuStack: ", e);
		}
	}

	public void Pop()
	{
		if (!IsMenuStackEmpty) { _menuStack.Pop().QueueFree(); }
		if (!IsMenuStackEmpty) { _menuStack.Peek().Show(); }
		else { GetTree().Paused = false; }
	}

	public void Clear()
	{
		foreach (Control menu in _menuStack) { menu.QueueFree(); }
		_menuStack.Clear();
		GetTree().Paused = false;
	}
}
