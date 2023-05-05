using System;
using System.Collections.Generic;

namespace ExpenditureTracker.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public decimal ExpenseAmount { get; set; }

    public DateTime ExpenseDate { get; set; }

    public string ExpenseDescription { get; set; } = null!;

    public int CategoryId { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual Category Category { get; set; } = null!;
}
