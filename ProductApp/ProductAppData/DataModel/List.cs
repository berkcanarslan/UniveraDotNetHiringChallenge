namespace ProductApp.ProductAppData.DataModel;

public class List
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? CompletionDate { get; set; }

    public List<ListProduct> ListProducts { get; set; }
}