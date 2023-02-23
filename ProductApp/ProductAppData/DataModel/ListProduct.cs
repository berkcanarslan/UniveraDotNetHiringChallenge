namespace ProductApp.ProductAppData.DataModel;

public class ListProduct
{
    public int Id { get; set; }
    public int ListId { get; set; }
    public List List { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}