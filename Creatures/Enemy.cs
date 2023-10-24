using Godot;
using System;
using System.Collections;

public partial class Enemy : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;

	[Export]
	public int Health {get; set; } = 5000;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Health <= 0)
		{
			QueueFree();
		}

	}

	public void Hit(int damage)
	{
		QueueFree();
	}
}
