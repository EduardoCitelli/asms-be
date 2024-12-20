﻿namespace ASMS.DTOs.Payments
{
    public class PaymentListDto : PaymentDto
    {
        public long Id { get; set; }

        public DateTime EmittedDate { get; set; }

        public string PayBy { get; set; } = string.Empty;
    }
}
