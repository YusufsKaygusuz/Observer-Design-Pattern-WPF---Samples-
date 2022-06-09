// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Globalization;
using System.Collections.Generic;

namespace BindingToMethod
{
    abstract public class Observer
    {
        public abstract string  Update(double degree);
    }

    public class FahrenheitTemp : Observer
    {
        public override string Update(double degree)
        {
            return ((degree - 32) / 9 * 5).ToString(CultureInfo.InvariantCulture) + " " + "Celsius";
        }
    }

    public class CelciusTemp : Observer
    {
        public override string Update(double degree)
        {
            return (degree * 9 / 5 + 32).ToString(CultureInfo.InvariantCulture) + " " + "Fahrenheit";
        }
    }
    /*
    public class KelvinTemp : Observer
    {
        public override string Update(double degree)
        {
            // Dönüşüm eklenebilir.
        }
    }
    */

    public class Temperature
    {
        public string TempType { get; set; }
        public double TempValue { get; set; }


        bool IsChanged;

        public bool IsChange
        {
            get
            {
                return IsChanged;
            }
            set
            {
                if (value == true)
                {
                    Notify(TempValue);
                    IsChanged = value;
                }
                else
                    IsChanged = value;
            }
        }

        List<Observer> TypeOfTemp;
      
        public Temperature()
        {
            this.TypeOfTemp = new List<Observer>();
        }
        public void AddNewType(Observer observer)
        {
            TypeOfTemp.Add(observer);
        }
        public void DeleteType(Observer observer)
        {
            TypeOfTemp.Remove(observer);
        }

        public void Notify(double Tempvalue)
        {
            TypeOfTemp.ForEach(g =>
            {
                g.Update(Tempvalue);
            });
        }
    }
}