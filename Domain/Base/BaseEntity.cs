namespace CQRS_Shop.Domain.Base;

public class BaseEntity{
    public int CreatedBy { get; set; }
    public DateTime CreatedIn { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedIn { get; set; }
    protected virtual void Validate(){}
}