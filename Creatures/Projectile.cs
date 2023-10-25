using Godot;
using System;

public partial class Projectile : Area2D
{

	[Export]
	
	//projectile speed
	public int Speed {get; set;	} = 1250;
	private Vector2 velocity = Vector2.Zero;
	private Vector2 direction = Vector2.Zero;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		velocity = velocity.Normalized() * Speed;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		// this is just stolen from the player class, just sends the velocity in the direction dictated by the movement input.
		
		Position += Transform.X * Speed * (float)delta;
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
		if(!body.IsInGroup("player")) // if we dont hit the player
		{
			Label lbl = GetNode<Label>("Label");
			lbl.Text = "Hit!";
			lbl.Show();
			body.QueueFree(); // for now just kill the thing it hits.
			QueueFree(); // kill the bullet
		}
		
		
	}

}
