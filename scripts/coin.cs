using Godot;
using System;

public partial class coin : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void onBodyEntered(Node2D body)
	{
		GetNode<GameManager>("%GameManager").addPoint();
		GetNode<AnimationPlayer>("AnimationPlayer").Play("pickup");

	}
}
