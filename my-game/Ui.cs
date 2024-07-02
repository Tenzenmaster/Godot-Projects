using Godot;
using System;
using System.Collections.Generic;

namespace MyGame;

public partial class Ui : CanvasLayer
{
	public bool IsMenuStackEmpty { get => _menuStack.Count == 0; }

	private Stack<Control> _menuStack = new();

	public override void _Ready()
	{
		// Test
		Push(GD.Load<PackedScene>("res://menu.tscn"), true);
	}

	public void Push(PackedScene menuScene, bool pause)
	{
		GetTree().Paused = pause;
		try
		{
			Control newMenu = menuScene.Instantiate<Control>();
			if (!IsMenuStackEmpty) { _menuStack.Peek().Hide(); }
			_menuStack.Push(newMenu);
			AddChild(newMenu);
		}
		catch (InvalidCastException e)
		{
			GD.PrintErr("Invalid cast to Control while pushing menu: ", e);
		}
	}

	public void Pop(bool pause)
	{
		if (!IsMenuStackEmpty) { _menuStack.Pop().QueueFree(); }
		if (!IsMenuStackEmpty) { _menuStack.Peek().Show(); }
		GetTree().Paused = pause;
	}

	public void Clear(bool pause)
	{
		foreach (Control menu in _menuStack) { menu.QueueFree(); }
		_menuStack.Clear();
		GetTree().Paused = pause;
	}
}
