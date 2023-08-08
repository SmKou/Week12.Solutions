using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class Item
{
    public int ItemId { get; set; }
    [Required(ErrorMessage = "The item's description cannot be empty.")]
    public string Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Item must be added to a category.")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public List<ItemTag> JoinEntities { get; }
    public ApplicationUser User { get; set; }
}
