﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VVVV.Utils.Win32;

namespace VVVV.Utils.IO
{
    public enum KeyNotificationKind
    {
        KeyDown,
        KeyPress,
        KeyUp,
        DeviceLost
    }

    public abstract class KeyNotification
    {
        public readonly KeyNotificationKind Kind;
        protected KeyNotification(KeyNotificationKind kind)
        {
            Kind = kind;
        }

        public bool IsKeyDown { get { return Kind == KeyNotificationKind.KeyDown; } }
        public bool IsKeyUp { get { return Kind == KeyNotificationKind.KeyUp; } }
        public bool IsKeyPress { get { return Kind == KeyNotificationKind.KeyPress; } }
        public bool IsDeviceLost { get { return Kind == KeyNotificationKind.DeviceLost; } }
    }

    public abstract class KeyCodeNotification : KeyNotification
    {
        public readonly Keys KeyCode;
        public KeyCodeNotification(KeyNotificationKind kind, Keys keyCode)
            : base(kind)
        {
            KeyCode = keyCode;
        }
    }

    public class KeyDownNotification : KeyCodeNotification
    {
        public KeyDownNotification(Keys keyCode) : this(new KeyEventArgs(keyCode)) { }
        public KeyDownNotification(KeyEventArgs args)
            : base(KeyNotificationKind.KeyDown, args.KeyCode)
        {
            origArgs = args;
        }
        KeyEventArgs origArgs;

        public bool Handled { get { return origArgs.Handled; } set { origArgs.Handled = value; } } 
    }

    public class KeyPressNotification : KeyNotification
    {
        public readonly char KeyChar;
        public KeyPressNotification(char keyChar)
            : base(KeyNotificationKind.KeyPress)
        {
            KeyChar = keyChar;
        }
    }

    public class KeyUpNotification : KeyCodeNotification
    {
        public KeyUpNotification(Keys keyCode)
            : base(KeyNotificationKind.KeyUp, keyCode)
        {
        }
    }

    public class KeyboardLostNotification : KeyNotification
    {
        public KeyboardLostNotification()
            : base(KeyNotificationKind.DeviceLost)
        {
        }
    }
}
