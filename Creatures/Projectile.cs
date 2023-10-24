using Godot;
using System;

public partial class Projectile : Area2D
{

	[Export]
	
	//projectile speed
	public int Speed {get; set;	} = 1250;
	private Vector2 velocity = Vector2.Zero;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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
		velocity = velocity.Normalized() * Speed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		// this is just stolen from the player class, just sends the velocity in the direction dictated by the movement input.
		
		Position += velocity * (float)delta;
		// for now, the projectile is only deleted on projectile timeout, but eventually we will implement logic for it hitting a wall, etc. probably clamp it to screensize.
	}

	private void OnProjectileTimeout()
	{
		QueueFree(); //delete the bullet whenever its life is over
	}



	/// <summary>
	/// Called when a body enters the projectile's hitbox. Basically when it hit something.
	/// </summary>
	/// <param name="body">The actual thing it hits.</param>
	private void OnBodyEntered(Node2D body)
	{
		if(body.IsInGroup("enemy"))
		{
			// do something to the enemy,, maybe cast it and call a function damage() or something that takes away hp?
		}
		QueueFree(); // delete the bullet
	}

}
