using Godot;
using System;

public partial class killzone : Area2D
{
	public Timer timer;
    public override void _Ready()
    {
		timer = GetNode<Timer>("Timer");
    }

    public void onBodyEntered(Node2D body)
	{
		GD.Print("Kill playeer");
		Engine.TimeScale = 0.5;
		body.GetNode("CollisionShape2D").QueueFree();
		timer.Start();
	}

	public void onTimerTimeout()
	{
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}
}
