using System.Runtime.InteropServices;

namespace Just_Game_Remaster;

internal static class Keyboard {

    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int key);

    public static bool IsKeyDown(ConsoleKey key) {
        var state = GetAsyncKeyState((int)key);
        bool result = (state & 0x8000) > 0;
        return result;
    }

}
