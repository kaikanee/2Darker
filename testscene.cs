using Godot;
using System;

public partial class testscene : Area2D
{
	[Export]
	public PackedScene Player {get; set;}

	[Export]
	public PackedScene Dummy {get; set;}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player player = Player.Instantiate<Player>();
		AddChild(player);
		Enemy enemy = Dummy.Instantiate<Enemy>();
		AddChild(enemy);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
