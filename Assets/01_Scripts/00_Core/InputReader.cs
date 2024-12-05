using UnityEngine;

public class InputReader : MonoSingleton<InputReader>
{
    public PlayerInput PlayerInput;
    private void Awake()
    {
        Debug.Log(PlayerInput);
    }

    public void FindInputManager()
    {
        Debug.Log(PlayerInput);
        if (GameObject.Find("Player") == null)
        {
            PlayerInput = null;
        }
        else
        {

            PlayerInput = GameObject.Find("Player").GetComponent<PlayerInputManager>().GetPlayerInput();
        }
    }


    public void OnFloorDisable()
    {

        if (PlayerInput is not null)
            PlayerInput.OnFloor.Disable();

    }

    public void OnFloorEnable()
    {
        if (PlayerInput is not null)
            PlayerInput.OnFloor.Enable();
    }



}
