﻿using MedicalPractice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPractice.Domain.Abstract
{
    public interface IMedicalProductsRepository
    {
        IEnumerable<Medical_Products> ProductsRepository { get; }
    }
}
