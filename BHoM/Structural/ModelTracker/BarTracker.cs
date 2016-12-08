using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base.Results;
using BHoM.Structural.Elements;

namespace BHoM.Structural.ModelTracker
{
    public class BarTracker : IResult
    {

        public static BarTracker TrackerFromBar(Bar bar)
        {
            BarTracker tracker = new BarTracker();
            tracker.Date = DateTime.Today;
            tracker.PropertyName = bar.SectionProperty.Name;
            tracker.Name = bar.Name;

            double length = bar.Length;
            double desityArea = bar.SectionProperty.GrossArea * bar.SectionProperty.Material.Density;

            tracker.Length = length;
            tracker.Mass = length * desityArea;

            tracker.Id = tracker.Date.ToShortDateString() + ":" + tracker.PropertyName + ":" + tracker.Name;

            return tracker;
        }

        public int CompareTo(object obj)
        {
            BarTracker r2 = obj as BarTracker;
            return Name.CompareTo(r2.Name);
        }

        public BarTracker()
        {
            Data = new object[6];
        }

        public object[] Data
        {
            get; set;

        }

        public string Id
        {
            get
            {
                return (string)Data[0];
            }

            set
            {
                Data[0] = value;
            }
        }


        public DateTime Date
        {
            get
            {
                return (DateTime)Data[1];
            }
            set
            {
                Data[1] = value;
            }
        }

        public string PropertyName
        {
            get
            {
                return (string)Data[2];
            }
            set
            {
                Data[2] = value;
            }
        }
        public string Name
        {
            get
            {
                return (string)Data[3];
            }
            set
            {
                Data[3] = value;
            }
        }

        public double Length
        {
            get
            {
                return (double)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }

        public double Mass
        {
            get
            {
                return (double)Data[5];
            }
            set
            {
                Data[5] = value;
            }
        }

        public string[] ColumnHeaders
        {

            get
            {
                return new string[] {
                    "Id",
                    "Date",
                    "PropertyName",
                    "Name",
                    "Length",
                    "Mass"};
            }
        }
    }
}
