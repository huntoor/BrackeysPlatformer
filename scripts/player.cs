using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 140.0f;
	public const float JumpVelocity = -300.0f;

	public AnimatedSprite2D animatedSprite2D;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("move_left", "move_right");

		// Flip player
		if (direction > 0)
		{
			animatedSprite2D.FlipH = false;
		}
		else if (direction < 0)
		{
			animatedSprite2D.FlipH = true;
		}

		// Play animations
		if (IsOnFloor())
		{
			if (direction == 0)
			{
				animatedSprite2D.Play("idle");
			}
			else
			{
				animatedSprite2D.Play("running");
			}
		}
		else
		{
			animatedSprite2D.Play("jump");
		}

		// Apply movement
		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
