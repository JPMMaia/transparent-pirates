using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour 
{
	public Texture[] Images;
	public RawImage CurrentImage;
    public AudioSource MainAudioSource;
    public AudioClip MainSound;
    public AudioClip FirstSound;
    public AudioClip FifthSound;
    public AudioClip SeventhSound;

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

            if(value == 0)
            {
                _audioSource.clip = FirstSound;
                _audioSource.volume = 0.3f;
                _audioSource.Play();
            }
            else if(value == 4)
            {
                _audioSource.Stop();
                _audioSource.clip = FifthSound;
                _audioSource.volume = 0.45f;
                _audioSource.Play();
            }
            else if(value == 6)
            {
                _audioSource.Stop();
                _audioSource.clip = SeventhSound;
                _audioSource.volume = 1.0f;
                _audioSource.Play();
            }
		}
	}
	private uint _currentSlide;
	private Timer _timer;
	private bool _elapsed;
    private AudioSource _audioSource;

	void Start () 
	{
        _audioSource = GetComponent<AudioSource>();

		CurrentSlide = 0;
		_elapsed = false;
		
		_timer = new Timer(2000.0);
		_timer.Elapsed += _timer_Elapsed;

		_timer.Start();

        MainAudioSource.loop = true;
        MainAudioSource.volume = 1.0f;
        MainAudioSource.Play();
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

                // Initiate game:
                SceneManager.LoadScene("TerrainScene");

                // Destroy object:
                Destroy(this.gameObject);

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
