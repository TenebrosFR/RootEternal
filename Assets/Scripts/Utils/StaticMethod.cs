﻿using System.Diagnostics;
using UnityEngine;
using static utils.StaticMethod;

namespace utils {
    public enum VectorAxis {
        X,
        Y,
        Z
    }
    public enum QuaternionAxis {
        X,
        Y,
        Z,
        W
    }
    public static partial class StaticMethod {
        #region transform
        public static Transform UpdatePosition(this Transform reference,float value,VectorAxis axis) {
            reference.position = reference.position.UpdateAxis(value, axis);
            return reference;
        }
        #endregion
        #region Vector2
        public static Vector2 UpdateAxis(this Vector2 movement, float newValue, VectorAxis axis, System.Exception error) {
            if (axis != VectorAxis.Z) return new Vector2(axis == VectorAxis.X ? newValue : movement.x, axis == VectorAxis.Y ? newValue : movement.y);
            else UnityEngine.Debug.LogError("Incorrect Axis Given to Vector2 UpdateAxis");
            return movement;
        }
        public static Vector2 Add(this Vector2 first, Vector2 second) {
            return new Vector2(first.x + second.x, first.y + second.y);
        }
        #endregion
        #region Transform
        public static void AddOffset(this Transform self, Vector3 offset) {
            self.position += offset;
        }
        #endregion
        #region Vector
        public static Vector3 Restricted(this Vector3 movement, bool x = false, bool y = false, bool z = false) {
            return new Vector3(x ? 0 : movement.x, y ? 0 : movement.y, z ? 0 : movement.z);
        }
        public static Vector3 Abs(this Vector3 vect) {
            return new Vector3(vect.x < 0 ? -vect.x : vect.x, vect.y < 0 ? -vect.y : vect.y, vect.z < 0 ? -vect.z : vect.z);
        }
        public static Vector3 UpdateAxis(this Vector3 movement, float newValue, VectorAxis axis) {
            return new Vector3(axis == VectorAxis.X ? newValue : movement.x, axis == VectorAxis.Y ? newValue : movement.y, axis == VectorAxis.Z ? newValue : movement.z);
        }
        public static Vector3 Divide(this Vector3 first, Vector3 second) {
            return new Vector3(first.x / second.x, first.y / second.y, first.z / second.z);
        }
        public static Vector3 Multiply(this Vector3 first, Vector3 second) {
            return new Vector3(first.x * second.x, first.y * second.y, first.z * second.z);
        }
        public static Vector3 Multiply(this Vector3 first, float second) {
            return new Vector3(first.x * second, first.y * second, first.z * second);
        }
        public static Vector3 Sub(this Vector3 first, Vector3 second) {
            return new Vector3(first.x - second.x, first.y - second.y, first.z - second.z);
        }
        #endregion
        #region Collider
        public static bool IsGrounded(this Collider obj) {
            return Physics.CheckSphere(obj.bounds.min, .2f, LayerMask.GetMask("Ground"));
        }
        #endregion
        #region Quaternion
        public static Quaternion Sub(this Quaternion first, Quaternion second) {
            return new Quaternion(first.x - second.x, first.y - second.y, first.z - second.z, first.w);
        }
        public static Quaternion Add(this Quaternion first, Quaternion second) {
            return new Quaternion(first.x + second.x, first.y + second.y, first.z + second.z, first.w);
        }
        public static Quaternion Update(this Quaternion inQuaternion, float newValue, QuaternionAxis axis) {
            return new Quaternion(axis == QuaternionAxis.X ? newValue : inQuaternion.x, axis == QuaternionAxis.Y ? newValue : inQuaternion.y, axis == QuaternionAxis.Z ? newValue : inQuaternion.z, axis == QuaternionAxis.W ? newValue : inQuaternion.w);
        }
        #endregion
    }
}