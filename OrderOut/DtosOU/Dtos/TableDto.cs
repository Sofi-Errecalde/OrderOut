﻿using OrderOut.EF.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOut.DtosOU.Dtos
{
    public class TableDto
    {
        public int AmountPeople { get; set; }
        public int State { get; set; }

    }
}
