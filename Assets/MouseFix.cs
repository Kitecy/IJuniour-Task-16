#if UNITY_EDITOR
using UnityEngine;

/*
 * ����������� ��� �������:
 * � ���� �� �������� ��������� � ����� ������� ����� ����� �� UI
 * ���� ������ ���������� ������.
*/

public static class MouseFix
{
    private static readonly string s_mouseName = "Mouse";

    [RuntimeInitializeOnLoadMethod]
    private static void ActivateMouse()
    {
        //List<InputDevice> devices = InputSystem.devices.ToList();
        //List<InputDevice> mouseDevices = devices.FindAll(x => x.displayName == s_mouseName);

        //foreach (InputDevice mouse in mouseDevices)
        //    InputSystem.EnableDevice(mouse);
    }
}
#endif