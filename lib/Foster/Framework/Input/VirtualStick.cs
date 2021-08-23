﻿using System;
using System.Numerics;

namespace Foster.Framework
{
    /// <summary>
    /// A Virtual Input Stick that can be mapped to different keyboards and gamepads
    /// </summary>
    public class VirtualStick
    {

        /// <summary>
        /// The Horizontal Axis
        /// </summary>
        public VirtualAxis Horizontal;

        /// <summary>
        /// The Vertical Axis
        /// </summary>
        public VirtualAxis Vertical;

        /// <summary>
        /// This Deadzone is applied to the Length of the combined Horizontal and Vertical axis values
        /// </summary>
        public float CircularDeadzone = 0f;

        /// <summary>
        /// Gets the current Virtual Stick value
        /// </summary>
        public Vector2 Value
        {
            get
            {
                var result = new Vector2(Horizontal.Value, Vertical.Value);
                if (CircularDeadzone != 0 && result.Length() < CircularDeadzone)
                    return Vector2.Zero;
                return result;
            }
        }

        /// <summary>
        /// Gets the current Virtual Stick value, ignoring Deadzones
        /// </summary>
        public Vector2 ValueNoDeadzone => new Vector2(Horizontal.ValueNoDeadzone, Vertical.ValueNoDeadzone);

        /// <summary>
        /// Gets the current Virtual Stick value, clamping to Integer Values
        /// </summary>
        public Point2 IntValue
        {
            get
            {
                var result = Value;
                return new Point2(MathF.Sign(result.X), MathF.Sign(result.Y));
            }
        }

        /// <summary>
        /// Gets the current Virtual Stick value, clamping to Integer values and Ignoring Deadzones
        /// </summary>
        public Point2 IntValueNoDeadzone => new Point2(Horizontal.IntValueNoDeadzone, Vertical.IntValueNoDeadzone);

        public VirtualStick(Input input, float circularDeadzone = 0f)
        {
            Horizontal = new VirtualAxis(input);
            Vertical = new VirtualAxis(input);
            CircularDeadzone = circularDeadzone;
        }

        public VirtualStick(Input input, VirtualAxis.Overlaps overlapBehaviour, float circularDeadzone = 0f)
        {
            Horizontal = new VirtualAxis(input, overlapBehaviour);
            Vertical = new VirtualAxis(input, overlapBehaviour);
            CircularDeadzone = circularDeadzone;
        }

        public VirtualStick Add(Keys left, Keys right, Keys up, Keys down)
        {
            Horizontal.Add(left, right);
            Vertical.Add(up, down);
            return this;
        }

        public VirtualStick Add(int controller, Buttons left, Buttons right, Buttons up, Buttons down)
        {
            Horizontal.Add(controller, left, right);
            Vertical.Add(controller, up, down);
            return this;
        }

        public VirtualStick Add(int controller, Axes horizontal, Axes vertical, float deadzoneHorizontal = 0f, float deadzoneVertical = 0f)
        {
            Horizontal.Add(controller, horizontal, deadzoneHorizontal);
            Vertical.Add(controller, vertical, deadzoneVertical);
            return this;
        }

        public VirtualStick AddLeftJoystick(int controller, float deadzoneHorizontal = 0, float deadzoneVertical = 0)
        {
            Horizontal.Add(controller, Axes.LeftX, deadzoneHorizontal);
            Vertical.Add(controller, Axes.LeftY, deadzoneVertical);
            return this;
        }

        public VirtualStick AddRightJoystick(int controller, float deadzoneHorizontal = 0, float deadzoneVertical = 0)
        {
            Horizontal.Add(controller, Axes.RightX, deadzoneHorizontal);
            Vertical.Add(controller, Axes.RightY, deadzoneVertical);
            return this;
        }

        public void Clear()
        {
            Horizontal.Clear();
            Vertical.Clear();
        }

    }
}
