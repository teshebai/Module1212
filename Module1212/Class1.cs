using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1212
{
    public delegate void PropertyeventHandler(object sender, PropertyeventArgs e);

    public interface iPropertychanged
    {
        event PropertyeventHandler Propertychanged;
    }

    public class PropertyeventArgs : EventArgs
    {
        public string PropertyName { get; private set; }

        public PropertyeventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
    public class SampleClass : iPropertychanged
    {
        private string sampleProperty;
        public event PropertyeventHandler Propertychanged;

        public string SampleProperty
        {
            get { return sampleProperty; }
            set
            {
                if (sampleProperty != value)
                {
                    sampleProperty = value;
                    OnPropertychanged("SampleProperty");
                }
            }
        }

        protected virtual void OnPropertychanged(string propertyName)
        {
            Propertychanged?.Invoke(this, new PropertyeventArgs(propertyName));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sampleObject = new SampleClass();
            sampleObject.Propertychanged += SampleObject_Propertychanged;

            sampleObject.SampleProperty = "New Value";
            Console.ReadKey();
        }

        private static void SampleObject_Propertychanged(object sender, PropertyeventArgs e)
        {
            Console.WriteLine($"Property changed: {e.PropertyName}");
        }
    }

}