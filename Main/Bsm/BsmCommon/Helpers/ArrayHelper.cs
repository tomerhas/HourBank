using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 namespace BsmCommon.Helpers
{
    public class ArrayHelper
    { 
        /// <summary>
        /// Reallocates an array with a new size, and copies the contents of the old array to the new array.
        /// </summary>
        /// <param name="oldArray">the old array, to be reallocated</param>
        /// <param name="newSize">the new array size</param>
        /// <returns> A new array with the same contents</returns>
        public static System.Array ResizeArray(System.Array oldArray, int newSize)
        {
            int oldSize = oldArray.Length;
            System.Type elementType = oldArray.GetType().GetElementType();
            System.Array newArray = System.Array.CreateInstance(elementType, newSize);
            int preserveLength = System.Math.Min(oldSize, newSize);
            if (preserveLength > 0)
                System.Array.Copy(oldArray, newArray, preserveLength);
            return newArray;
        }
    }
}
