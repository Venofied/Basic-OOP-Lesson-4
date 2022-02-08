using BuildingLibrary;

namespace Task4
{
    internal class Programm
    {
        static void Main()
        {
            Building.Creator.CreateBuild();
            Building.Creator.SaveHashTable();
            Building.Creator.SeacrhHashTable(Building.Creator.Key);
            Building.Creator.DeleteHashTable(Building.Creator.Key);
        }
    }
}
