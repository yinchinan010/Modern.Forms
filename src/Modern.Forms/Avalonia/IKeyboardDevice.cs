﻿#nullable disable

// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using System.ComponentModel;

namespace Avalonia.Input
{
    [Flags, Obsolete("Use KeyModifiers and PointerPointProperties")]
    enum InputModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        LeftMouseButton = 16,
        RightMouseButton = 32,
        MiddleMouseButton = 64
    }

    [Flags]
    enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Meta = 8,
    }

    [Flags]
    enum KeyStates
    {
        None = 0,
        Down = 1,
        Toggled = 2,
    }

    [Flags]
    enum RawInputModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Meta = 8,
        LeftMouseButton = 16,
        RightMouseButton = 32,
        MiddleMouseButton = 64,
        KeyboardMask = Alt | Control | Shift | Meta
    }

    internal static class KeyModifiersUtils
    {
        public static KeyModifiers ConvertToKey(RawInputModifiers modifiers) =>
            (KeyModifiers)(modifiers & RawInputModifiers.KeyboardMask);
    }

    interface IKeyboardDevice : IInputDevice, INotifyPropertyChanged
    {
    //    IInputElement FocusedElement { get; }

    //    void SetFocusedElement(
    //        IInputElement element, 
    //        NavigationMethod method,
    //        InputModifiers modifiers);
    }
}
