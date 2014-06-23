// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

namespace WestWorld
{
    /// <summary>
    /// From Location.h
    /// </summary>
    public enum LocationType
    {
        Shack,
        Goldmine,
        Bank,
        Saloon,
    };

    /// <summary>
    /// From EntityNames.h
    /// </summary>
    public enum EntityType
    {
        MinerBob,
        Elsa,
    };

    // Function GetNameOfEntity is not needed in C# (use EntityType.ToString).
}
