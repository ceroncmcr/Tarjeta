﻿namespace Application.Transactions.Histories;

public class HistoryResponse
{
    public string CardNumber { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
