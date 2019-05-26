using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor;

public class enemi : MonoBehaviour
{
	public SpriteRenderer head;
	public Sprite[]	headSprites;
	public SpriteRenderer body;
	public Sprite[]	bodySprites;
	public Weapon weapon;
    public AudioClip    deathClip;


	public int blockingLayer;

	[SerializeField] private List<Transform> _checkPoints = null;
	private int _index = 0;
	private player _player;
	private Rigidbody2D _rb;
	private float _timerRun;
	private IEnumerator _routine = null;
    private AudioSource _audioSrc;
	private bool		_isAlive = true;

	public enum stateEnemy
	{
		stay,
		sound_alert,
		view_player,
		routine
	}

	public stateEnemy state = stateEnemy.routine;
	public Vector3 soundPosition = Vector3.zero;

	// Use this for initialization
	void Start()
	{
		state = stateEnemy.routine;
		_player = player.instance;
		_rb = gameObject.GetComponent<Rigidbody2D>();
		if (player.instance != null)
		{
			player.instance.OnGunShooted += ListenBullet;
			// Debug.Log("listen to bullet in start");
		}
		// string path = "Assets/Sprites/characters/body/" + Random.Range(1, 4).ToString() + ".png";
		// Debug.Log("body = " + path);
		// body.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
		body.sprite = bodySprites[Random.Range(0, bodySprites.Length)];

		// path = "Assets/Sprites/characters/head/" + Random.Range(1, 13).ToString() + ".png";
		// Debug.Log("head = " + path);
		// head.sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
		head.sprite = headSprites[Random.Range(0, headSprites.Length)];

        _audioSrc = GetComponent<AudioSource>();

	}

	void OnDisable()
	{
		player.instance.OnGunShooted -= ListenBullet;
	}

	void ListenBullet(Vector3 pos, float dist)
	{
		// Debug.Log("ListenBullet : " + pos + dist);
		if (Vector3.Distance(pos, transform.position) <= dist)
		{
			// Debug.Log("Enemi " + name + " heard the bullet shot.");
			state = stateEnemy.sound_alert;
			soundPosition = pos;
			_timerRun = 2f;
		}
	}

	void Update()
	{
		if (_isAlive == false)
			return;
		
		Vector3 heading = _player.transform.position - transform.position;
		LayerMask mask = LayerMask.GetMask("door", "Wall", "player");
		float angle = Vector2.Angle(transform.up, heading);
		float dist = 1f;
		if (isWithin(angle, 155f, 205f))
			dist = 7f;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, heading, dist, mask);
		if (hit && hit.collider.gameObject.layer == LayerMask.NameToLayer("player"))
		{
			state = stateEnemy.view_player;
			if (_routine == null)
			{
				_routine = fireEverySeconds();
				StartCoroutine(_routine);
			}
			_timerRun = 3f;
		}
		else if (_routine != null)
		{
			StopCoroutine(_routine);
			_routine = null;
		}
		// return;
		switch (state)
		{
			case stateEnemy.stay:
				if (_checkPoints != null)
					state = stateEnemy.routine;
				break;
			case stateEnemy.sound_alert:
				_timerRun -= Time.deltaTime;
				if (changeState(_timerRun < 0, stateEnemy.stay))
					break;
				runToPos(soundPosition);
				changeState(soundPosition == transform.position, stateEnemy.stay);
				break;
			case stateEnemy.view_player:
				_timerRun -= Time.deltaTime;
				if (changeState(_timerRun < 0, stateEnemy.stay)) break;
				runToPos(_player.transform.position);
				break;
			case stateEnemy.routine:
				patrolling();
				break;
		};
	}

	public void Die()
    {
        _audioSrc.clip = deathClip;
        _audioSrc.Play();
		StopAllCoroutines();
		_isAlive = false;
		Destroy(gameObject, deathClip.length);
    }

	/**************************/
	/*      Patrole stuff     */
	/**************************/

	public void changePatrolPath(List<Transform> checkPoints)
	{
		_checkPoints = checkPoints;
		_index = 0;
	}

	public void emptyCheckPoint()
	{
		_checkPoints = null;
	}

	public void patrolling()
	{
		if (_checkPoints == null || _checkPoints.Count == 0)
		{
			state = stateEnemy.routine;
			return;
		}
		runToPos(_checkPoints[_index].position);
		if (onPosition(transform.position, _checkPoints[_index].position))
		{
			// Debug.Log("Goto next check point");
			_index++;
			if (_index == _checkPoints.Count)
				_index = 0;
		}
	}

	/**************** PROTECTED ****************/

	protected void runToPos(Vector3 pos)
	{
		Vector2 velocity = pos - transform.position;
		velocity.Normalize();
		_rb.velocity = velocity * 3f;
		float angle = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x) * Mathf.Rad2Deg;
		angle += 90;
		transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + angle);
	}

	protected bool onPosition(Vector3 from, Vector3 to)
	{
		if (isWithin(from.x, to.x - 0.5f, to.x + 0.5f) && isWithin(from.y, to.y - 0.5f, to.y + 0.5f))
			return true;
		return false;
	}

	protected bool changeState(bool condition, stateEnemy newState)
	{
		if (condition)
		{
			state = newState;
			return true;
		}
		return false;
	}

	/**************** PRIVATE ****************/

	private bool isWithin(float value, float min, float max)
	{
		if (value >= min && value <= max)
			return true;
		return false;
	}

	private IEnumerator fireEverySeconds()
	{
		if (weapon)
		{
			weapon.fire(transform.position, transform.localRotation);
			weapon.ammo = 20;
		}
		yield return new WaitForSeconds(1);
		if (_routine != null)
			StartCoroutine(fireEverySeconds());
	}
}
