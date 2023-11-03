using Godot;
using System;

public partial class ArmingSword : Area2D
{
	[Export]
	public AnimatedSprite2D meleeItem;
	[Export]
	public AnimatedSprite2D meleeTrail;
	[Export]
	public CollisionPolygon2D meleeCol;
	[Export]
	public float attackSize;
	[Export]
	public float attackTime;

	public bool isEquipped = true;
	public bool isAttacking = false;
	private Tween tween;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		meleeTrail.SpeedScale = ((1/attackTime) * 6);
		meleeTrail.Visible = false;
		meleeCol.SetDeferred("collision_layer", 0);
		meleeCol.SetDeferred("collision_mask", 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!isEquipped) {
			meleeItem.Visible = false;
		} else {
			meleeItem.Visible = true;
		}
		if(Input.IsActionPressed("equip1"))
		{
			isEquipped = true;
		}
		if(Input.IsActionPressed("equip2"))
		{
			isEquipped = false;
		}
		if(Input.IsActionPressed("attack") && isEquipped == true && isAttacking == false)
		{
			Attack();
		}
	}

	private void _OnBodyEntered(Node2D body)
	{
		if(!body.IsInGroup("player") && isAttacking == true) // if we dont hit the player
		{
			Label lbl = GetNode<Label>("Label");
			lbl.Text = "Hit!";
			lbl.Show();
			body.QueueFree(); // for now just kill the thing it hits.
		}
		
		
	}

	private void Attack() {
		isAttacking = true;
		meleeTrail.Visible = true;
		tween = CreateTween();
		RotationDegrees = 90 - attackSize;
		tween.TweenProperty(this, "rotation_degrees", 90 + attackSize, attackTime);
		meleeTrail.Play();

		tween.Play();
		tween.Connect("finished", new Callable(this, "_OnTweenComplete"));
	}

	private void _OnTweenComplete() {
		meleeTrail.Stop();
		meleeTrail.Visible = false;
		isAttacking = false;
		RotationDegrees = 90;
	}
}
