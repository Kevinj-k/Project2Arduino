	using Godot;
	using System;
	using System.IO.Ports;

	public partial class Character : Node2D
	{
		private SerialPort serialPort;

		private Node characterSwitcher;	

		public override void _Ready()
		{

			characterSwitcher = GetNode("Node2D");
			try
			{
				serialPort = new SerialPort("COM5", 9600)
				{
					DtrEnable = true,
					RtsEnable = true,
					ReadTimeout = 50,
				};
				serialPort.Open();
				GD.Print("Port opened successfully");
			}
			catch (Exception ex)
			{
				GD.PrintErr("Failed to open serial port: " + ex.Message);
			}
		}

		public override void _Process(double delta)
		{
			if (serialPort == null || !serialPort.IsOpen)
			{
				return;
			}

			try
			{
				if (serialPort.BytesToRead > 0)
				{
					string uid = serialPort.ReadLine().Trim().Replace(" ","").ToUpperInvariant();
					if (!string.IsNullOrEmpty(uid))
					{
						GD.Print("Scanned UID: " + uid);
						OnTagScanned(uid);
					}
				}
			}
			catch (TimeoutException)
			{
				
			}
			catch (Exception ex)
			{
				GD.PrintErr("Serial read error: " + ex.Message);
			}
		}
		private void OnTagScanned(string uid)
		{
			switch (uid)
			{
				case "9C910002":
				GD.Print("Switching to character 1!");
				characterSwitcher.Call("changeCharacter1");
				break;

				case "11C9FC64":
				GD.Print("Switching to character 2!");
				characterSwitcher.Call("changeCharacter2");
				break;
			}
		}
	}

