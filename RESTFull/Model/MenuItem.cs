using System;
using System.ComponentModel.DataAnnotations;

///<summary>
/// A meal that's available on the menu
///</summary>
public class MenuItem
{
    [KeyAttribute]
    public int Id { get; set; }

    [RequiredAttribute]
    public string Name { get; set; }

}