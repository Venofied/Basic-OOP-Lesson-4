using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary
{
    public sealed class Building
    {
        public static int LastID = 0;

        private int _id;
        private double _height;
        private int _numberOfStoreys;
        private int _countFlats;
        private int _countEntrances;

        public int CountEntrances
        {
            get { return _countEntrances; }
            private set { _countEntrances = value; }
        }

        public int CountFlats
        {
            get { return _countFlats; }
            private set { _countFlats = value; }
        }

        public int NumberOfStoreys
        {
            get { return _numberOfStoreys; }
            private set { _numberOfStoreys = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = GetID(); }
        }

        public double Height // в метрах
        {
            get { return _height; }
            private set { _height = value; }
        }
        private Building() :this(countEntrances: 0, countFlats: 0, numberOfStoreys: 0)
        {

        }
        private Building(int countEntrances, int countFlats, int numberOfStoreys)
        {
            CountEntrances = countEntrances;
            CountFlats = countFlats;
            NumberOfStoreys = numberOfStoreys;
            Height = CalcHeight();
        }

        public double CalcHeight()
        {
            double HeightOneFlat = 2.9;
            double HeightBasement = 1.5;
            double AtticHeight = 2;

            double Height = HeightBasement + AtticHeight + (HeightOneFlat * CountFlats);
            return Height;
        }
        public double CalcHeightFlat()
        {
            double HeightBasement = 1.5;
            double AtticHeight = 2;
            return (Height / CountFlats) - (HeightBasement + AtticHeight);
        }
        public int CaclCountFlatsOnEntrances()
        {
            return CountFlats / CountEntrances;
        }
        public int CalcCountFlatsOnStorey()
        {
            return (CountFlats / CountEntrances) / NumberOfStoreys;
        }
        private int GetID()
        {
            return LastID++;
        }

        public class Creator
        {

            private static Building Build = null;

            public static int Key = 0;

            static HashTable ht = new HashTable();
            public static Building Create()
            {
                return new Building();
            }
            public static Building Create(int countEntrances, int countFlats, int numberOfStoreys)
            {
                return new Building(countEntrances, countFlats, numberOfStoreys)
                {
                    CountEntrances = countEntrances,
                    CountFlats = countFlats,
                    NumberOfStoreys = numberOfStoreys
                };
            }
            public static void CreateBuild()
            {
                Build  = Creator.Create(3, 4, 10);
            }
            public static void SaveHashTable()
            {
                if (Build is null)
                {
                    CreateBuild();
                }

                ht.Insert(Key++.ToString(), Build);
            }

            public static void DeleteHashTable(int key)
            {
                if (Build is null)
                {
                    CreateBuild();
                }
                ht.Delete(key.ToString());
            }
            public static void SeacrhHashTable(int key)
            {
                if (Build is null)
                {
                    CreateBuild();
                }
                ht.Search(key.ToString());                
            }
        }
    }
}
