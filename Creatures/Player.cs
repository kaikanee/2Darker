using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;

	[Export]
	public PackedScene Arrows {get; set;}

	public Vector2 ArenaSize; //Size of the module



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ArenaSize = GetViewportRect().Size;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if(Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}
		if(Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}
		if(Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}
		if(Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		Position += velocity * (float)delta;
		Position = new Vector2(x: Mathf.Clamp(Position.X, 0, ArenaSize.X), y: Mathf.Clamp(Position.Y, 0, ArenaSize.Y));

		if(Input.IsActionPressed("attack"))
		{
			Timer attackTimer = GetNode<Timer>("AttackTimer");
			if(attackTimer.TimeLeft <= 0)
			{
				attackTimer.Start();
				Attack();
			}
		}

	}

	private void Attack()
	{
		Projectile arrow = Arrows.Instantiate<Projectile>();
		AddChild(arrow);
	}
}
