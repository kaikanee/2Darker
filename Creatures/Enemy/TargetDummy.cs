using Godot;
using System;

public partial class TargetDummy : Area2D
{
	[Export]
	public int Health {get; set; } = 1000;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Label lbl = GetNode<Label>("DamageNumber");
		lbl.Text = "YAHOO!!!";
		lbl.Show();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node2D body)
	{
		
		Timer timer = GetNode<Timer>("InvulnTimer"); //can implement this better by simply disabling the hitbox

		Label lbl = GetNode<Label>("DamageNumber");
		Projectile hitter = body as Projectile;
		lbl.Text = "YeeYee";
		lbl.Show();
		timer.Start();
		
		
	}


	private void OnInvulnTimerTimeout()
	{
		Label lbl = GetNode<Label>("DamageNumber");
		lbl.Hide();
	}
}



