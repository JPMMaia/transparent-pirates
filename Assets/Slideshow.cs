using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour 
{
	public Texture[] Images;
	public RawImage CurrentImage;

	private uint CurrentSlide
	{
		get
		{
			return _currentSlide;
		}
		set
		{
			_currentSlide = value;

			if (value < Images.Length) 
			{
				CurrentImage.texture = Images[value];
			}
		}
	}
	private uint _currentSlide;
	private Timer _timer;
	private bool _elapsed;

	void Start () 
	{
		CurrentSlide = 0;
		_elapsed = false;
		
		_timer = new Timer(2000.0);
		_timer.Elapsed += _timer_Elapsed;

		_timer.Start();
	}

	public void Update()
	{
		if (_elapsed) 
		{
			_elapsed = false;

			if (CurrentSlide == Images.Length - 1) 
			{
				// Stop timer:
				_timer.Stop();

				// TODO Initiate game:

				return;
			}

			CurrentSlide += 1;
		}
	}

	void _timer_Elapsed (object sender, ElapsedEventArgs e)
	{
		_elapsed = true;
	}
}
