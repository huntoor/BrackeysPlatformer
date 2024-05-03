using Godot;
using System;

public partial class GameManager : Node
{
	private int score = 0;

	public void addPoint()
	{
		score += 1;
		GD.Print(score);
		GetNode<Label>("ScoreLabel").Text = "You have collected " + score + " coins.";
	}
}
