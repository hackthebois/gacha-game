using Godot;

public partial class CameraMovement : Camera3D
{
	[Export]
	public int Speed { get; set; } = 20;

	[Export]
	public int ScrollSpeed { get; set; } = 1;

	[Export]
	public int MinZoom { get; set; } = 5;

	[Export]
	public int MaxZoom { get; set; } = 30;

	public override void _Process(double delta)
	{
		// Zoom
		if (Input.IsActionJustReleased("zoom_in"))
		{
			Size = Mathf.Clamp(Size - ScrollSpeed, MinZoom, MaxZoom);
		}
		if (Input.IsActionJustReleased("zoom_out"))
		{
			Size = Mathf.Clamp(Size + ScrollSpeed, MinZoom, MaxZoom);
		}

		// Movement
		Vector2 inputDirection = Input.GetVector("move_left", "move_right", "move_down", "move_up");
		Vector3 movement = new Vector3(inputDirection.X, 0, -inputDirection.Y);
		GlobalTranslate(movement * Speed * (float)delta);
	}
};
