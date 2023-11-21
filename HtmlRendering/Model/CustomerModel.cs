using System;

namespace HtmlRendering.Model;

public class CustomerModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public decimal SpentAmount { get; set; }
}